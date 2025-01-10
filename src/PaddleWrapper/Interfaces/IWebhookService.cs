using PaddleWrapper.Models.Webhooks;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for managing Paddle webhooks
    /// </summary>
    public interface IWebhookService
    {
        /// <summary>
        /// Lists all webhook settings
        /// </summary>
        Task<WebhookSettings[]> ListWebhookSettingsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new webhook endpoint
        /// </summary>
        Task<WebhookSettings> CreateWebhookSettingsAsync(WebhookSettings settings, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing webhook endpoint
        /// </summary>
        Task<WebhookSettings> UpdateWebhookSettingsAsync(string endpointId, WebhookSettings settings, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a webhook endpoint
        /// </summary>
        Task DeleteWebhookSettingsAsync(string endpointId, CancellationToken cancellationToken = default);
    }
}