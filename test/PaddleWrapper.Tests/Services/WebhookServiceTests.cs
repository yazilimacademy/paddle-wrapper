using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Events.Webhooks;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Webhooks;
using PaddleWrapper.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

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
            var expectedSettings = new[]
            {
                new WebhookSettings
                {
                    Type = "webhook",
                    Description = "Test webhook endpoint",
                    Destination = "https://api.example.com/webhooks",
                    Active = true,
                    ApiVersion = "1.0",
                    SubscribedEvents = new[] { "subscription.created", "subscription.updated" }
                }
            };

            var response = new WebhookResponse<WebhookSettings[]>
            {
                Data = expectedSettings
            };

            _mockClient
                .Setup(x => x.GetAsync<WebhookResponse<WebhookSettings[]>>("notification-settings", It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _service.ListWebhookSettingsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(expectedSettings[0].Destination, result[0].Destination);
            Assert.Equal(expectedSettings[0].Active, result[0].Active);
            Assert.Equal(expectedSettings[0].ApiVersion, result[0].ApiVersion);
            Assert.Equal(expectedSettings[0].SubscribedEvents, result[0].SubscribedEvents);
        }

        [Fact]
        public async Task CreateWebhookSettingsAsync_ShouldCreateAndReturnWebhookSettings()
        {
            // Arrange
            var newSettings = new WebhookSettings
            {
                Type = "webhook",
                Description = "Test webhook endpoint",
                Destination = "https://api.example.com/webhooks",
                Active = true,
                ApiVersion = "1.0",
                SubscribedEvents = new[] { "subscription.created" }
            };

            var request = new WebhookRequest { Data = newSettings };
            var response = new WebhookResponse<WebhookSettings> { Data = newSettings };

            _mockClient
                .Setup(x => x.PostAsync<WebhookRequest, WebhookResponse<WebhookSettings>>("notification-settings", request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _service.CreateWebhookSettingsAsync(newSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newSettings.Destination, result.Destination);
            Assert.Equal(newSettings.Active, result.Active);
            Assert.Equal(newSettings.ApiVersion, result.ApiVersion);
            Assert.Equal(newSettings.SubscribedEvents, result.SubscribedEvents);
        }

        [Fact]
        public async Task UpdateWebhookSettingsAsync_ShouldUpdateAndReturnWebhookSettings()
        {
            // Arrange
            var endpointId = "whk_123";
            var updatedSettings = new WebhookSettings
            {
                Type = "webhook",
                Description = "Updated webhook endpoint",
                Destination = "https://api.example.com/webhooks/updated",
                Active = false,
                ApiVersion = "1.1",
                SubscribedEvents = new[] { "subscription.created", "subscription.canceled" }
            };

            var request = new WebhookRequest { Data = updatedSettings };
            var response = new WebhookResponse<WebhookSettings> { Data = updatedSettings };

            _mockClient
                .Setup(x => x.PatchAsync<WebhookRequest, WebhookResponse<WebhookSettings>>($"notification-settings/{endpointId}", request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _service.UpdateWebhookSettingsAsync(endpointId, updatedSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedSettings.Destination, result.Destination);
            Assert.Equal(updatedSettings.Active, result.Active);
            Assert.Equal(updatedSettings.ApiVersion, result.ApiVersion);
            Assert.Equal(updatedSettings.SubscribedEvents, result.SubscribedEvents);
        }

        [Fact]
        public async Task DeleteWebhookSettingsAsync_ShouldDeleteWebhookSettings()
        {
            // Arrange
            var endpointId = "whk_123";
            var deleteCompleted = false;

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
            var webhookEvent = new WebhookEvent
            {
                EventId = "evt_123",
                EventType = "subscription.created",
                OccurredAt = DateTime.UtcNow,
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