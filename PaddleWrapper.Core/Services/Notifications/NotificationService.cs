using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Notification;

namespace PaddleWrapper.Core.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "notification";

        public NotificationService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<NotificationSettings>> GetNotificationSettingsAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<NotificationSettings>>($"{BaseEndpoint}/settings");
        }

        public async Task<PaddleResponse<NotificationSettings>> UpdateNotificationSettingsAsync(NotificationSettings settings)
        {
            return await _httpClient.PostAsync<PaddleResponse<NotificationSettings>>($"{BaseEndpoint}/settings", settings);
        }

        public async Task<PaddleResponse<WebhookTestResult>> TestWebhookAsync()
        {
            return await _httpClient.PostAsync<PaddleResponse<WebhookTestResult>>($"{BaseEndpoint}/webhook/test", null);
        }

        public async Task<PaddleResponse<WebhookTestResult[]>> GetWebhookHistoryAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<WebhookTestResult[]>>($"{BaseEndpoint}/webhook/history");
        }

        public async Task<PaddleResponse<bool>> RetryWebhookAsync(string eventId)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/webhook/{eventId}/retry", null);
        }

        public async Task<PaddleResponse<bool>> ConfigureEmailNotificationsAsync(bool enabled, string[] emails)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/email/configure", new { enabled, emails });
        }

        public async Task<PaddleResponse<string>> RotateWebhookSecretAsync()
        {
            return await _httpClient.PostAsync<PaddleResponse<string>>($"{BaseEndpoint}/webhook/secret/rotate", null);
        }
    }
}