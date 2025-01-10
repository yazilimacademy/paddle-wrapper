using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PaddleWrapper.Configuration;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Interfaces;
using Polly;
using Polly.Retry;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Clients
{
    /// <summary>
    /// Implementation of the Paddle API client
    /// </summary>
    public class PaddleClient : IPaddleClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly PaddleOptions _options;
        private readonly ILogger<PaddleClient> _logger;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
        private bool _disposed;

        /// <summary>
        /// Creates a new instance of PaddleClient
        /// </summary>
        public PaddleClient(PaddleOptions options, ILogger<PaddleClient> logger)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            options.Validate();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(options.GetEffectiveBaseUrl()),
                Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds)
            };

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.ApiKey}");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _retryPolicy = Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .Or<TaskCanceledException>()
                .WaitAndRetryAsync(
                    options.MaxRetryAttempts,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (outcome, timeSpan, retryCount, context) =>
                    {
                        _logger.LogWarning(
                            "Retry {RetryCount} after {RetryInterval}s delay due to {ExceptionType}: {ExceptionMessage}",
                            retryCount,
                            timeSpan.TotalSeconds,
                            outcome.Exception.GetType().Name,
                            outcome.Exception.Message);
                        return Task.CompletedTask;
                    });
        }

        /// <inheritdoc/>
        public async Task<TResponse> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await SendRequestAsync<object>(HttpMethod.Get, endpoint, null, cancellationToken);
            return await DeserializeResponseAsync<TResponse>(response);
        }

        /// <inheritdoc/>
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await SendRequestAsync(HttpMethod.Post, endpoint, request, cancellationToken);
            return await DeserializeResponseAsync<TResponse>(response);
        }

        /// <inheritdoc/>
        public async Task<TResponse> PatchAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await SendRequestAsync(HttpMethod.Patch, endpoint, request, cancellationToken);
            return await DeserializeResponseAsync<TResponse>(response);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string endpoint, CancellationToken cancellationToken = default)
        {
            await SendRequestAsync<object>(HttpMethod.Delete, endpoint, null, cancellationToken);
        }

        private async Task<HttpResponseMessage> SendRequestAsync<TRequest>(HttpMethod method, string endpoint, TRequest content, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, endpoint);

            if (content != null)
            {
                string json = JsonConvert.SerializeObject(content);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            _logger.LogInformation("Sending {Method} request to {Endpoint}", method, endpoint);

            HttpResponseMessage response = await _retryPolicy.ExecuteAsync(async () =>
            {
                HttpResponseMessage result = await _httpClient.SendAsync(request, cancellationToken);
                if (!result.IsSuccessStatusCode)
                {
                    string errorContent = await result.Content.ReadAsStringAsync();
                    _logger.LogError("Request failed with status {StatusCode}. Response: {Response}", result.StatusCode, errorContent);
                    throw new PaddleException($"Request failed with status code {result.StatusCode}. Response: {errorContent}", result.StatusCode);
                }
                return result;
            });

            return response;
        }

        private async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize response: {Content}", content);
                throw new PaddleException("Failed to deserialize response", ex);
            }
        }

        /// <summary>
        /// Disposes the HTTP client
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the HTTP client
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _httpClient?.Dispose();
            }

            _disposed = true;
        }
    }
}