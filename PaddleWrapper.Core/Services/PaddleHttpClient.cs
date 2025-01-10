using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Exceptions;
using PaddleWrapper.Core.Interfaces;
using System.Net;
using System.IO;
using System.IO.Compression;
using PaddleWrapper.Core.Models;

namespace PaddleWrapper.Core.Services
{
    public class PaddleHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly PaddleOptions _options;
        private readonly IPaddleLogger _logger;

        public PaddleHttpClient(HttpClient httpClient, IOptions<PaddleOptions> options, IPaddleLogger logger)
        {
            _httpClient = httpClient;
            _options = options.Value;
            _logger = logger;

            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(_options.TimeoutSeconds);

            if (!string.IsNullOrEmpty(_options.ApiKey))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiKey}");
            }

            _httpClient.DefaultRequestHeaders.Add("Paddle-Version", _options.ApiVersion);
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                _logger.LogDebug($"Making GET request to {endpoint}");
                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
                return await HandleResponseAsync<T>(response);
            }
            catch (Exception ex) when (ex is not PaddleException)
            {
                _logger.LogError($"Error making GET request to {endpoint}", ex);
                throw new PaddleException("An error occurred while making the request", ex);
            }
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                _logger.LogDebug($"Making POST request to {endpoint}");
                StringContent? content = data != null 
                    ? new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json") 
                    : null;
                HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
                return await HandleResponseAsync<T>(response);
            }
            catch (Exception ex) when (ex is not PaddleException)
            {
                _logger.LogError($"Error making POST request to {endpoint}", ex);
                throw new PaddleException("An error occurred while making the request", ex);
            }
        }

        private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response)
        {
            var contentEncoding = response.Content.Headers.ContentEncoding;
            _logger.LogInformation($"Response Content-Encoding: {string.Join(", ", contentEncoding)}");

            var content = await DecompressResponse(response);
            _logger.LogInformation($"Decompressed API Response: {content}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    // Paddle API yanıt formatını kontrol et
                    if (content.Contains("\"data\":"))
                    {
                        var paddleResponse = JsonConvert.DeserializeObject<PaddleApiResponse>(content);
                        var responseType = typeof(T).GetGenericArguments().FirstOrDefault();
                        
                        if (responseType != null)
                        {
                            if (typeof(T).GetGenericTypeDefinition() == typeof(PaddleResponse<>))
                            {
                                // Tek nesne mi dizi mi kontrol et
                                var isArray = responseType.IsArray;
                                var elementType = isArray ? responseType.GetElementType() : responseType;

                                object convertedData;
                                if (paddleResponse.Data is JArray dataArray)
                                {
                                    if (isArray)
                                    {
                                        // Diziyi dönüştür
                                        var list = dataArray.Select(item => 
                                            JsonConvert.DeserializeObject(item.ToString(), elementType)).ToList();
                                        var array = Array.CreateInstance(elementType, list.Count);
                                        list.CopyTo((object[])array);
                                        convertedData = array;
                                    }
                                    else
                                    {
                                        // Tek nesneyi dönüştür (ilk eleman)
                                        convertedData = JsonConvert.DeserializeObject(
                                            dataArray.First().ToString(), elementType);
                                    }
                                }
                                else
                                {
                                    // Tek nesne
                                    convertedData = JsonConvert.DeserializeObject(
                                        paddleResponse.Data.ToString(), elementType);
                                }

                                // Generic PaddleResponse oluştur
                                var paddleResponseType = typeof(PaddleResponse<>).MakeGenericType(responseType);
                                var result = Activator.CreateInstance(paddleResponseType);
                                paddleResponseType.GetProperty("Success").SetValue(result, true);
                                paddleResponseType.GetProperty("Response").SetValue(result, convertedData);
                                paddleResponseType.GetProperty("Error").SetValue(result, null);

                                return (T)result;
                            }
                        }
                    }

                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch (JsonException ex)
                {
                    _logger.LogError("Error deserializing response", ex);
                    throw new PaddleException("Failed to deserialize the response", ex);
                }
            }

            _logger.LogWarning($"Error response received: {content}");

            throw response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => new PaddleAuthenticationException("Invalid API credentials"),
                HttpStatusCode.BadRequest => new PaddleValidationException("The request was invalid"),
                HttpStatusCode.NotFound => new PaddleException("The requested resource was not found"),
                _ => new PaddleApiException(
                                        $"API request failed with status code {(int)response.StatusCode}",
                                        (int)response.StatusCode,
                                        response.ReasonPhrase),
            };
        }

        private async Task<string> DecompressResponse(HttpResponseMessage response)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            
            if (response.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                using var gzipStream = new GZipStream(contentStream, CompressionMode.Decompress);
                using var reader = new StreamReader(gzipStream);
                return await reader.ReadToEndAsync();
            }
            else if (response.Content.Headers.ContentEncoding.Contains("deflate"))
            {
                using var deflateStream = new DeflateStream(contentStream, CompressionMode.Decompress);
                using var reader = new StreamReader(deflateStream);
                return await reader.ReadToEndAsync();
            }

            using var normalReader = new StreamReader(contentStream);
            return await normalReader.ReadToEndAsync();
        }
    }
}