using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class SubscriptionsApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "subscriptions";

        internal SubscriptionsApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all subscriptions
        /// </summary>
        public async Task<List<Subscription>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Subscription>>? result = JsonSerializer.Deserialize<ApiResponse<List<Subscription>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a subscription by ID
        /// </summary>
        public async Task<Subscription> GetAsync(string subscriptionId)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{subscriptionId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Subscription>? result = JsonSerializer.Deserialize<ApiResponse<Subscription>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new subscription
        /// </summary>
        public async Task<Subscription> CreateAsync(Subscription subscription)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }

            string json = JsonSerializer.Serialize(subscription);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Subscription>? result = JsonSerializer.Deserialize<ApiResponse<Subscription>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing subscription
        /// </summary>
        public async Task<Subscription> UpdateAsync(string subscriptionId, Subscription subscription)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }

            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }

            string json = JsonSerializer.Serialize(subscription);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{subscriptionId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Subscription>? result = JsonSerializer.Deserialize<ApiResponse<Subscription>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Pauses a subscription
        /// </summary>
        public async Task<Subscription> PauseAsync(string subscriptionId, DateTime? resumeAt = null)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }

            var request = new { resume_at = resumeAt };
            string json = JsonSerializer.Serialize(request);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync($"{BasePath}/{subscriptionId}/pause", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Subscription>? result = JsonSerializer.Deserialize<ApiResponse<Subscription>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Resumes a paused subscription
        /// </summary>
        public async Task<Subscription> ResumeAsync(string subscriptionId)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }

            HttpResponseMessage response = await _httpClient.PostAsync($"{BasePath}/{subscriptionId}/resume", null);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Subscription>? result = JsonSerializer.Deserialize<ApiResponse<Subscription>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Cancels a subscription
        /// </summary>
        public async Task<Subscription> CancelAsync(string subscriptionId, DateTime? effectiveAt = null)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }

            var request = new { effective_at = effectiveAt };
            string json = JsonSerializer.Serialize(request);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync($"{BasePath}/{subscriptionId}/cancel", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Subscription>? result = JsonSerializer.Deserialize<ApiResponse<Subscription>>(responseContent);

            return result.Data;
        }
    }
}