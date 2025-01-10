using System;
using System.Collections.Generic;

namespace PaddleWrapper.Core.Models.Notification
{
    /// <summary>
    /// Bildirim ayarlarını temsil eden sınıf.
    /// </summary>
    public class NotificationSettings
    {
        /// <summary>
        /// Webhook URL'i
        /// </summary>
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Webhook gizli anahtarı
        /// </summary>
        public string WebhookSecret { get; set; }

        /// <summary>
        /// Bildirim tipleri
        /// </summary>
        public List<string> NotificationTypes { get; set; } = new List<string>();

        /// <summary>
        /// E-posta bildirimleri aktif mi?
        /// </summary>
        public bool EmailNotificationsEnabled { get; set; }

        /// <summary>
        /// Bildirim alacak e-posta adresleri
        /// </summary>
        public List<string> NotificationEmails { get; set; } = new List<string>();

        /// <summary>
        /// Bildirim ayarlarının son güncelleme tarihi
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Webhook durumu
        /// </summary>
        public WebhookStatus WebhookStatus { get; set; }

        /// <summary>
        /// Webhook test sonuçları
        /// </summary>
        public List<WebhookTestResult> WebhookTestResults { get; set; } = new List<WebhookTestResult>();
    }

    /// <summary>
    /// Webhook durumunu temsil eden sınıf.
    /// </summary>
    public class WebhookStatus
    {
        /// <summary>
        /// Webhook aktif mi?
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Son başarılı webhook çağrısı tarihi
        /// </summary>
        public DateTime? LastSuccessfulCall { get; set; }

        /// <summary>
        /// Son başarısız webhook çağrısı tarihi
        /// </summary>
        public DateTime? LastFailedCall { get; set; }

        /// <summary>
        /// Son hata mesajı
        /// </summary>
        public string LastErrorMessage { get; set; }

        /// <summary>
        /// Başarısız deneme sayısı
        /// </summary>
        public int FailureCount { get; set; }
    }

    /// <summary>
    /// Webhook test sonucunu temsil eden sınıf.
    /// </summary>
    public class WebhookTestResult
    {
        /// <summary>
        /// Test tarihi
        /// </summary>
        public DateTime TestDate { get; set; }

        /// <summary>
        /// Test başarılı mı?
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// HTTP durum kodu
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Yanıt süresi (ms)
        /// </summary>
        public int ResponseTime { get; set; }

        /// <summary>
        /// Hata mesajı
        /// </summary>
        public string ErrorMessage { get; set; }
    }
} 