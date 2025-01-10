using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Notification;

namespace PaddleWrapper.Core.Interfaces
{
    /// <summary>
    /// Bildirim işlemleri için servis arayüzü.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Bildirim ayarlarını getirir.
        /// </summary>
        Task<PaddleResponse<NotificationSettings>> GetNotificationSettingsAsync();

        /// <summary>
        /// Bildirim ayarlarını günceller.
        /// </summary>
        Task<PaddleResponse<NotificationSettings>> UpdateNotificationSettingsAsync(NotificationSettings settings);

        /// <summary>
        /// Webhook URL'ini test eder.
        /// </summary>
        Task<PaddleResponse<WebhookTestResult>> TestWebhookAsync();

        /// <summary>
        /// Webhook geçmişini getirir.
        /// </summary>
        Task<PaddleResponse<WebhookTestResult[]>> GetWebhookHistoryAsync();

        /// <summary>
        /// Webhook'u yeniden gönderir.
        /// </summary>
        Task<PaddleResponse<bool>> RetryWebhookAsync(string eventId);

        /// <summary>
        /// E-posta bildirimlerini yapılandırır.
        /// </summary>
        Task<PaddleResponse<bool>> ConfigureEmailNotificationsAsync(bool enabled, string[] emails);

        /// <summary>
        /// Webhook gizli anahtarını yeniler.
        /// </summary>
        Task<PaddleResponse<string>> RotateWebhookSecretAsync();
    }
}