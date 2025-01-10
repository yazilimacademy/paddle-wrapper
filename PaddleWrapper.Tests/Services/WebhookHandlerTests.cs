using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Services;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class WebhookHandlerTests
    {
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;
        private readonly WebhookHandler _webhookHandler;

        public WebhookHandlerTests()
        {
            _options = new PaddleOptions
            {
                WebhookSecret = "test_webhook_secret"
            };
            _optionsMock = new Mock<IOptions<PaddleOptions>>();
            _optionsMock.Setup(x => x.Value).Returns(_options);
            _webhookHandler = new WebhookHandler(_optionsMock.Object);
        }

        [Fact]
        public void ValidateWebhookSignature_ValidSignature_ReturnsTrue()
        {
            // Arrange
            string payload = "test_payload";
            string signature = ComputeSignature(payload, _options.WebhookSecret);

            // Act
            bool result = _webhookHandler.ValidateWebhookSignature(payload, signature);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ValidateWebhookSignature_InvalidSignature_ReturnsFalse()
        {
            // Arrange
            string payload = "test_payload";
            string invalidSignature = "invalid_signature";

            // Act
            bool result = _webhookHandler.ValidateWebhookSignature(payload, invalidSignature);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateWebhookSignature_NoSecret_ThrowsException()
        {
            // Arrange
            _options.WebhookSecret = null;
            string payload = "test_payload";
            string signature = "some_signature";

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                _webhookHandler.ValidateWebhookSignature(payload, signature));
        }

        [Fact]
        public void ParseWebhookEvent_ValidPayload_ReturnsEvent()
        {
            // Arrange
            string payload = @"{
                ""event_type"": ""subscription_created"",
                ""event_id"": ""evt_123"",
                ""occurred_at"": ""2023-01-01T12:00:00Z"",
                ""data"": { ""subscription_id"": 123 }
            }";

            // Act
            Core.Models.Webhook.WebhookEvent result = _webhookHandler.ParseWebhookEvent(payload);

            // Assert
            result.Should().NotBeNull();
            result.EventType.Should().Be("subscription_created");
            result.EventId.Should().Be("evt_123");
        }

        [Fact]
        public void ParseWebhookEvent_InvalidPayload_ThrowsException()
        {
            // Arrange
            string invalidPayload = "invalid_json";

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                _webhookHandler.ParseWebhookEvent(invalidPayload));
        }

        private string ComputeSignature(string payload, string secret)
        {
            using HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(secret));
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}