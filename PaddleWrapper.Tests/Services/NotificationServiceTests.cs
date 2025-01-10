using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Notification;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Notifications;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class NotificationServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public NotificationServiceTests()
        {
            _loggerMock = new Mock<IPaddleLogger>();
            _options = new PaddleOptions
            {
                ApiKey = "test_api_key",
                VendorId = "test_vendor_id"
            };
            _optionsMock = new Mock<IOptions<PaddleOptions>>();
            _optionsMock.Setup(x => x.Value).Returns(_options);
        }

        [Fact]
        public async Task GetNotificationSettingsAsync_ReturnsSettings()
        {
            // Arrange
            var expectedSettings = new NotificationSettings 
            { 
                WebhookUrl = "https://example.com/webhook",
                WebhookStatus = new WebhookStatus { IsActive = true }
            };
            var expectedResponse = new PaddleResponse<NotificationSettings> { Success = true, Response = expectedSettings };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var notificationService = new NotificationService(paddleHttpClient);

            // Act
            var result = await notificationService.GetNotificationSettingsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.WebhookUrl.Should().Be("https://example.com/webhook");
            result.Response.WebhookStatus.IsActive.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateNotificationSettingsAsync_ValidSettings_ReturnsUpdatedSettings()
        {
            // Arrange
            var settings = new NotificationSettings 
            { 
                WebhookUrl = "https://example.com/webhook",
                WebhookStatus = new WebhookStatus { IsActive = true }
            };
            var expectedResponse = new PaddleResponse<NotificationSettings> { Success = true, Response = settings };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var notificationService = new NotificationService(paddleHttpClient);

            // Act
            var result = await notificationService.UpdateNotificationSettingsAsync(settings);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.WebhookUrl.Should().Be("https://example.com/webhook");
            result.Response.WebhookStatus.IsActive.Should().BeTrue();
        }

        [Fact]
        public async Task TestWebhookAsync_ReturnsTestResult()
        {
            // Arrange
            var expectedResult = new WebhookTestResult 
            { 
                IsSuccess = true,
                ErrorMessage = "Webhook test successful"
            };
            var expectedResponse = new PaddleResponse<WebhookTestResult> { Success = true, Response = expectedResult };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var notificationService = new NotificationService(paddleHttpClient);

            // Act
            var result = await notificationService.TestWebhookAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.IsSuccess.Should().BeTrue();
            result.Response.ErrorMessage.Should().Be("Webhook test successful");
        }

        [Fact]
        public async Task GetWebhookHistoryAsync_ReturnsHistory()
        {
            // Arrange
            var expectedHistory = new[]
            {
                new WebhookTestResult { IsSuccess = true, ErrorMessage = "First webhook" },
                new WebhookTestResult { IsSuccess = true, ErrorMessage = "Second webhook" }
            };
            var expectedResponse = new PaddleResponse<WebhookTestResult[]> { Success = true, Response = expectedHistory };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var notificationService = new NotificationService(paddleHttpClient);

            // Act
            var result = await notificationService.GetWebhookHistoryAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
        }

        [Fact]
        public async Task RotateWebhookSecretAsync_ReturnsNewSecret()
        {
            // Arrange
            var expectedResponse = new PaddleResponse<string> { Success = true, Response = "new_webhook_secret" };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var notificationService = new NotificationService(paddleHttpClient);

            // Act
            var result = await notificationService.RotateWebhookSecretAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().Be("new_webhook_secret");
        }
    }
} 