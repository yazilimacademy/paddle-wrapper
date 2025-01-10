using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class WebhooksApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "webhooks";

        internal WebhooksApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all webhooks
        /// </summary>
        public async Task<List<Webhook>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Webhook>>? result = JsonSerializer.Deserialize<ApiResponse<List<Webhook>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a webhook by ID
        /// </summary>
        public async Task<Webhook> GetAsync(string webhookId)
        {
            if (string.IsNullOrEmpty(webhookId))
            {
                throw new ArgumentNullException(nameof(webhookId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{webhookId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Webhook>? result = JsonSerializer.Deserialize<ApiResponse<Webhook>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new webhook
        /// </summary>
        public async Task<Webhook> CreateAsync(Webhook webhook)
        {
            if (webhook == null)
            {
                throw new ArgumentNullException(nameof(webhook));
            }

            string json = JsonSerializer.Serialize(webhook);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Webhook>? result = JsonSerializer.Deserialize<ApiResponse<Webhook>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing webhook
        /// </summary>
        public async Task<Webhook> UpdateAsync(string webhookId, Webhook webhook)
        {
            if (string.IsNullOrEmpty(webhookId))
            {
                throw new ArgumentNullException(nameof(webhookId));
            }

            if (webhook == null)
            {
                throw new ArgumentNullException(nameof(webhook));
            }

            string json = JsonSerializer.Serialize(webhook);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{webhookId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Webhook>? result = JsonSerializer.Deserialize<ApiResponse<Webhook>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Deletes a webhook
        /// </summary>
        public async Task DeleteAsync(string webhookId)
        {
            if (string.IsNullOrEmpty(webhookId))
            {
                throw new ArgumentNullException(nameof(webhookId));
            }

            HttpResponseMessage response = await _httpClient.DeleteAsync($"{BasePath}/{webhookId}");
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Lists webhook events
        /// </summary>
        public async Task<List<WebhookEvent>> ListEventsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/events");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<WebhookEvent>>? result = JsonSerializer.Deserialize<ApiResponse<List<WebhookEvent>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a webhook event by ID
        /// </summary>
        public async Task<WebhookEvent> GetEventAsync(string eventId)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                throw new ArgumentNullException(nameof(eventId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/events/{eventId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<WebhookEvent>? result = JsonSerializer.Deserialize<ApiResponse<WebhookEvent>>(content);

            return result.Data;
        }
    }
}