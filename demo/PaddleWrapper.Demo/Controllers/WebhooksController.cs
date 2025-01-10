using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Events.Webhooks;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Webhooks;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhooksController : ControllerBase
    {
        private readonly IWebhookService _webhookService;
        private readonly ILogger<WebhooksController> _logger;

        public WebhooksController(IWebhookService webhookService, ILogger<WebhooksController> logger)
        {
            _webhookService = webhookService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all webhook settings
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<WebhookSettings[]>> GetWebhookSettings()
        {
            return await _webhookService.ListWebhookSettingsAsync();
        }

        /// <summary>
        /// Creates a new webhook endpoint
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<WebhookSettings>> CreateWebhookSettings(WebhookSettings settings)
        {
            return await _webhookService.CreateWebhookSettingsAsync(settings);
        }

        /// <summary>
        /// Updates an existing webhook endpoint
        /// </summary>
        [HttpPatch("{endpointId}")]
        public async Task<ActionResult<WebhookSettings>> UpdateWebhookSettings(string endpointId, WebhookSettings settings)
        {
            return await _webhookService.UpdateWebhookSettingsAsync(endpointId, settings);
        }

        /// <summary>
        /// Deletes a webhook endpoint
        /// </summary>
        [HttpDelete("{endpointId}")]
        public async Task<IActionResult> DeleteWebhookSettings(string endpointId)
        {
            await _webhookService.DeleteWebhookSettingsAsync(endpointId);
            return NoContent();
        }

        /// <summary>
        /// Receives and processes webhook events from Paddle
        /// </summary>
        [HttpPost("receive")]
        public async Task<IActionResult> ReceiveWebhook([FromBody] WebhookEvent webhookEvent)
        {
            _logger.LogInformation("Webhook event received: {EventType} with ID: {EventId}",
                webhookEvent.EventType, webhookEvent.EventId);

            // Process based on event type
            switch (webhookEvent.EventType)
            {
                case "subscription.created":
                    await HandleSubscriptionCreatedAsync(webhookEvent);
                    break;
                case "subscription.updated":
                    await HandleSubscriptionUpdatedAsync(webhookEvent);
                    break;
                case "subscription.canceled":
                    await HandleSubscriptionCanceledAsync(webhookEvent);
                    break;
                default:
                    _logger.LogWarning("Unhandled webhook event type: {EventType}", webhookEvent.EventType);
                    break;
            }

            return Ok();
        }

        private async Task HandleSubscriptionCreatedAsync(WebhookEvent webhookEvent)
        {
            _logger.LogInformation("Processing subscription.created event");
            // Handle subscription creation
            await Task.CompletedTask;
        }

        private async Task HandleSubscriptionUpdatedAsync(WebhookEvent webhookEvent)
        {
            _logger.LogInformation("Processing subscription.updated event");
            // Handle subscription update
            await Task.CompletedTask;
        }

        private async Task HandleSubscriptionCanceledAsync(WebhookEvent webhookEvent)
        {
            _logger.LogInformation("Processing subscription.canceled event");
            // Handle subscription cancellation
            await Task.CompletedTask;
        }
    }
}