using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Events.Webhooks;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Webhooks;
using PaddleWrapper.Services;

namespace PaddleWrapper.Tests.Services
{
    public class WebhookServiceTests
    {
        private readonly Mock<IPaddleClient> _mockClient;
        private readonly Mock<ILogger<WebhookService>> _mockLogger;
        private readonly WebhookService _service;

        public WebhookServiceTests()
        {
            _mockClient = new Mock<IPaddleClient>();
            _mockLogger = new Mock<ILogger<WebhookService>>();
            _service = new WebhookService(_mockClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListWebhookSettingsAsync_ShouldReturnWebhookSettings()
        {
            // Arrange
            WebhookSettings[] expectedSettings = new[]
            {
                new WebhookSettings
                {
                    Active = true,
                    ApiVersion = "1.0",
                    EndpointUrl = "https://api.example.com/webhooks",
                    SubscribedEvents = new[] { "subscription.created", "subscription.updated" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<WebhookSettings[]>("notification-settings", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedSettings);

            // Act
            WebhookSettings[] result = await _service.ListWebhookSettingsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(expectedSettings[0].EndpointUrl, result[0].EndpointUrl);
            Assert.Equal(expectedSettings[0].Active, result[0].Active);
            Assert.Equal(expectedSettings[0].ApiVersion, result[0].ApiVersion);
            Assert.Equal(expectedSettings[0].SubscribedEvents, result[0].SubscribedEvents);
        }

        [Fact]
        public async Task CreateWebhookSettingsAsync_ShouldCreateAndReturnWebhookSettings()
        {
            // Arrange
            WebhookSettings newSettings = new()
            {
                Active = true,
                ApiVersion = "1.0",
                EndpointUrl = "https://api.example.com/webhooks",
                SubscribedEvents = new[] { "subscription.created" }
            };

            _mockClient
                .Setup(x => x.PostAsync<WebhookSettings, WebhookSettings>("notification-settings", newSettings, It.IsAny<CancellationToken>()))
                .ReturnsAsync(newSettings);

            // Act
            WebhookSettings result = await _service.CreateWebhookSettingsAsync(newSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newSettings.EndpointUrl, result.EndpointUrl);
            Assert.Equal(newSettings.Active, result.Active);
            Assert.Equal(newSettings.ApiVersion, result.ApiVersion);
            Assert.Equal(newSettings.SubscribedEvents, result.SubscribedEvents);
        }

        [Fact]
        public async Task UpdateWebhookSettingsAsync_ShouldUpdateAndReturnWebhookSettings()
        {
            // Arrange
            string endpointId = "whk_123";
            WebhookSettings updatedSettings = new()
            {
                Active = false,
                ApiVersion = "1.1",
                EndpointUrl = "https://api.example.com/webhooks/updated",
                SubscribedEvents = new[] { "subscription.created", "subscription.canceled" }
            };

            _mockClient
                .Setup(x => x.PatchAsync<WebhookSettings, WebhookSettings>($"notification-settings/{endpointId}", updatedSettings, It.IsAny<CancellationToken>()))
                .ReturnsAsync(updatedSettings);

            // Act
            WebhookSettings result = await _service.UpdateWebhookSettingsAsync(endpointId, updatedSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedSettings.EndpointUrl, result.EndpointUrl);
            Assert.Equal(updatedSettings.Active, result.Active);
            Assert.Equal(updatedSettings.ApiVersion, result.ApiVersion);
            Assert.Equal(updatedSettings.SubscribedEvents, result.SubscribedEvents);
        }

        [Fact]
        public async Task DeleteWebhookSettingsAsync_ShouldDeleteWebhookSettings()
        {
            // Arrange
            string endpointId = "whk_123";
            bool deleteCompleted = false;

            _mockClient
                .Setup(x => x.DeleteAsync($"notification-settings/{endpointId}", It.IsAny<CancellationToken>()))
                .Callback(() => deleteCompleted = true)
                .Returns(Task.CompletedTask);

            // Act
            await _service.DeleteWebhookSettingsAsync(endpointId);

            // Assert
            Assert.True(deleteCompleted);
            _mockClient.Verify(x => x.DeleteAsync($"notification-settings/{endpointId}", It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task WebhookEvent_ShouldDeserializeCorrectly()
        {
            // Arrange
            WebhookEvent webhookEvent = new()
            {
                EventId = "evt_123",
                OccurredAt = DateTime.UtcNow,
                EventType = "subscription.created",
                Data = new { subscription_id = "sub_123" }
            };

            // Assert
            Assert.NotNull(webhookEvent);
            Assert.Equal("evt_123", webhookEvent.EventId);
            Assert.Equal("subscription.created", webhookEvent.EventType);
            Assert.NotNull(webhookEvent.Data);
        }
    }
}