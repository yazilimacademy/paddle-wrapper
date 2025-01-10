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
            var response = await _client.GetAsync<WebhookResponse<WebhookSettings[]>>("notification-settings", cancellationToken);
            return response.Data;
        }

        /// <summary>
        /// Creates a new webhook endpoint
        /// </summary>
        public async Task<WebhookSettings> CreateWebhookSettingsAsync(WebhookSettings settings, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating webhook settings");
            var response = await _client.PostAsync<WebhookSettings, WebhookResponse<WebhookSettings>>("notification-settings", settings, cancellationToken);
            return response.Data;
        }

        /// <summary>
        /// Updates an existing webhook endpoint
        /// </summary>
        public async Task<WebhookSettings> UpdateWebhookSettingsAsync(string endpointId, WebhookSettings settings, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Updating webhook settings with ID: {EndpointId}", endpointId);
            var response = await _client.PatchAsync<WebhookSettings, WebhookResponse<WebhookSettings>>($"notification-settings/{endpointId}", settings, cancellationToken);
            return response.Data;
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