using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Models.Webhook;
using System.Security.Cryptography;
using System.Text;

namespace PaddleWrapper.Core.Services
{
    /// <summary>
    /// Paddle webhook olaylarını işlemek için kullanılan sınıf.
    /// </summary>
    public class WebhookHandler
    {
        private readonly PaddleOptions _options;

        /// <summary>
        /// WebhookHandler sınıfının yeni bir örneğini oluşturur.
        /// </summary>
        /// <param name="options">Paddle yapılandırma seçenekleri.</param>
        public WebhookHandler(IOptions<PaddleOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Webhook imzasının geçerliliğini doğrular.
        /// </summary>
        /// <param name="payload">Doğrulanacak webhook payload'ı.</param>
        /// <param name="signature">Paddle tarafından sağlanan imza.</param>
        /// <returns>İmza geçerliyse true, değilse false.</returns>
        /// <exception cref="InvalidOperationException">Webhook secret yapılandırılmamışsa fırlatılır.</exception>
        public bool ValidateWebhookSignature(string payload, string signature)
        {
            if (string.IsNullOrEmpty(_options.WebhookSecret))
            {
                throw new InvalidOperationException("Webhook secret is not configured");
            }

            using HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(_options.WebhookSecret));
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            string computedSignature = BitConverter.ToString(computedHash).Replace("-", "").ToLower();

            return computedSignature == signature.ToLower();
        }

        /// <summary>
        /// Webhook payload'ını parse ederek olay nesnesine dönüştürür.
        /// </summary>
        /// <param name="payload">Parse edilecek webhook payload'ı.</param>
        /// <returns>Parse edilmiş webhook olayı.</returns>
        /// <exception cref="InvalidOperationException">Payload geçerli bir JSON değilse fırlatılır.</exception>
        public WebhookEvent ParseWebhookEvent(string payload)
        {
            try
            {
                return JsonConvert.DeserializeObject<WebhookEvent>(payload);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to parse webhook payload", ex);
            }
        }

        /// <summary>
        /// Webhook olayını işler ve uygun işleyiciye yönlendirir.
        /// </summary>
        /// <param name="webhookEvent">İşlenecek webhook olayı.</param>
        /// <returns>İşleme tamamlandığında dönen Task.</returns>
        /// <exception cref="NotSupportedException">Desteklenmeyen olay tipi için fırlatılır.</exception>
        public async Task HandleWebhookEventAsync(WebhookEvent webhookEvent)
        {
            switch (webhookEvent.EventType)
            {
                case WebhookEventTypes.SubscriptionCreated:
                    await HandleSubscriptionCreatedAsync(webhookEvent);
                    break;

                case WebhookEventTypes.SubscriptionUpdated:
                    await HandleSubscriptionUpdatedAsync(webhookEvent);
                    break;

                case WebhookEventTypes.SubscriptionCancelled:
                    await HandleSubscriptionCancelledAsync(webhookEvent);
                    break;

                case WebhookEventTypes.PaymentSucceeded:
                    await HandlePaymentSucceededAsync(webhookEvent);
                    break;

                case WebhookEventTypes.PaymentRefunded:
                    await HandlePaymentRefundedAsync(webhookEvent);
                    break;

                case WebhookEventTypes.PaymentFailed:
                    await HandlePaymentFailedAsync(webhookEvent);
                    break;

                default:
                    throw new NotSupportedException($"Event type {webhookEvent.EventType} is not supported");
            }
        }

        /// <summary>
        /// Abonelik oluşturma olayını işler.
        /// </summary>
        /// <param name="webhookEvent">İşlenecek webhook olayı.</param>
        protected virtual Task HandleSubscriptionCreatedAsync(WebhookEvent webhookEvent)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Abonelik güncelleme olayını işler.
        /// </summary>
        /// <param name="webhookEvent">İşlenecek webhook olayı.</param>
        protected virtual Task HandleSubscriptionUpdatedAsync(WebhookEvent webhookEvent)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Abonelik iptal olayını işler.
        /// </summary>
        /// <param name="webhookEvent">İşlenecek webhook olayı.</param>
        protected virtual Task HandleSubscriptionCancelledAsync(WebhookEvent webhookEvent)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Başarılı ödeme olayını işler.
        /// </summary>
        /// <param name="webhookEvent">İşlenecek webhook olayı.</param>
        protected virtual Task HandlePaymentSucceededAsync(WebhookEvent webhookEvent)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Ödeme iade olayını işler.
        /// </summary>
        /// <param name="webhookEvent">İşlenecek webhook olayı.</param>
        protected virtual Task HandlePaymentRefundedAsync(WebhookEvent webhookEvent)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Başarısız ödeme olayını işler.
        /// </summary>
        /// <param name="webhookEvent">İşlenecek webhook olayı.</param>
        protected virtual Task HandlePaymentFailedAsync(WebhookEvent webhookEvent)
        {
            return Task.CompletedTask;
        }
    }
}