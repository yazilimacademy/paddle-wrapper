using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class NotificationsApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "notifications";

        internal NotificationsApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all notifications
        /// </summary>
        public async Task<List<Notification>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Notification>>? result = JsonSerializer.Deserialize<ApiResponse<List<Notification>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a notification by ID
        /// </summary>
        public async Task<Notification> GetAsync(string notificationId)
        {
            if (string.IsNullOrEmpty(notificationId))
            {
                throw new ArgumentNullException(nameof(notificationId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{notificationId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Notification>? result = JsonSerializer.Deserialize<ApiResponse<Notification>>(content);

            return result.Data;
        }

        /// <summary>
        /// Lists all attempts for a notification
        /// </summary>
        public async Task<List<NotificationAttempt>> ListAttemptsAsync(string notificationId)
        {
            if (string.IsNullOrEmpty(notificationId))
            {
                throw new ArgumentNullException(nameof(notificationId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{notificationId}/attempts");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<NotificationAttempt>>? result = JsonSerializer.Deserialize<ApiResponse<List<NotificationAttempt>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a specific attempt for a notification
        /// </summary>
        public async Task<NotificationAttempt> GetAttemptAsync(string notificationId, string attemptId)
        {
            if (string.IsNullOrEmpty(notificationId))
            {
                throw new ArgumentNullException(nameof(notificationId));
            }

            if (string.IsNullOrEmpty(attemptId))
            {
                throw new ArgumentNullException(nameof(attemptId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{notificationId}/attempts/{attemptId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<NotificationAttempt>? result = JsonSerializer.Deserialize<ApiResponse<NotificationAttempt>>(content);

            return result.Data;
        }

        /// <summary>
        /// Replays a notification
        /// </summary>
        public async Task<Notification> ReplayAsync(string notificationId)
        {
            if (string.IsNullOrEmpty(notificationId))
            {
                throw new ArgumentNullException(nameof(notificationId));
            }

            HttpResponseMessage response = await _httpClient.PostAsync($"{BasePath}/{notificationId}/replay", null);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Notification>? result = JsonSerializer.Deserialize<ApiResponse<Notification>>(content);

            return result.Data;
        }
    }
}