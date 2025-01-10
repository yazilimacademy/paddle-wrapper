using Microsoft.Extensions.Logging;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Webhooks;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Services
{
    /// <summary>
    /// Service for managing Paddle webhooks
    /// </summary>
    public class WebhookService : IWebhookService
    {
        private readonly IPaddleClient _client;
        private readonly ILogger<WebhookService> _logger;

        /// <summary>
        /// Creates a new instance of WebhookService
        /// </summary>
        public WebhookService(IPaddleClient client, ILogger<WebhookService> logger)
        {
            _client = client;
            _logger = logger;
        }

        /// <summary>
        /// Lists all webhook settings
        /// </summary>
        public async Task<WebhookSettings[]> ListWebhookSettingsAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving webhook settings");
            return await _client.GetAsync<WebhookSettings[]>("notification-settings", cancellationToken);
        }

        /// <summary>
        /// Creates a new webhook endpoint
        /// </summary>
        public async Task<WebhookSettings> CreateWebhookSettingsAsync(WebhookSettings settings, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating webhook settings");
            return await _client.PostAsync<WebhookSettings, WebhookSettings>("notification-settings", settings, cancellationToken);
        }

        /// <summary>
        /// Updates an existing webhook endpoint
        /// </summary>
        public async Task<WebhookSettings> UpdateWebhookSettingsAsync(string endpointId, WebhookSettings settings, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Updating webhook settings with ID: {EndpointId}", endpointId);
            return await _client.PatchAsync<WebhookSettings, WebhookSettings>($"notification-settings/{endpointId}", settings, cancellationToken);
        }

        /// <summary>
        /// Deletes a webhook endpoint
        /// </summary>
        public async Task DeleteWebhookSettingsAsync(string endpointId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Deleting webhook settings with ID: {EndpointId}", endpointId);
            await _client.DeleteAsync($"notification-settings/{endpointId}", cancellationToken);
        }
    }
}