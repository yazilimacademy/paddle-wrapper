using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Exceptions;
using PaddleWrapper.Core.Interfaces;
using System.Net;

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
                StringContent? content = data != null ? new StringContent(JsonConvert.SerializeObject(data)) : null;
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
            string content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    _logger.LogDebug($"Successful response received: {content}");
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
    }
}