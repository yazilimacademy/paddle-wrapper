using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Subscriptions;
using PaddleWrapper.Services;

namespace PaddleWrapper.Tests.Services
{
    public class SubscriptionServiceTests
    {
        private readonly Mock<IPaddleClient> _mockClient;
        private readonly Mock<ILogger<SubscriptionService>> _mockLogger;
        private readonly SubscriptionService _service;

        public SubscriptionServiceTests()
        {
            _mockClient = new Mock<IPaddleClient>();
            _mockLogger = new Mock<ILogger<SubscriptionService>>();
            _service = new SubscriptionService(_mockClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListSubscriptionsAsync_ShouldReturnSubscriptions()
        {
            // Arrange
            PaddleResponse<List<Subscription>> expectedResponse = new()
            {
                Data = new List<Subscription>
                {
                    new() { Id = "sub_1", CustomerId = "ctm_1" },
                    new() { Id = "sub_2", CustomerId = "ctm_2" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Subscription>>>("/subscriptions", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Subscription>> result = await _service.ListSubscriptionsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("sub_1", result.Data[0].Id);
            Assert.Equal("sub_2", result.Data[1].Id);
        }

        [Fact]
        public async Task GetSubscriptionAsync_WithValidId_ShouldReturnSubscription()
        {
            // Arrange
            string subscriptionId = "sub_1";
            PaddleResponse<Subscription> expectedResponse = new()
            {
                Data = new Subscription { Id = subscriptionId, CustomerId = "ctm_1" }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<Subscription>>($"/subscriptions/{subscriptionId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Subscription> result = await _service.GetSubscriptionAsync(subscriptionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(subscriptionId, result.Data.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetSubscriptionAsync_WithInvalidId_ShouldThrowArgumentException(string subscriptionId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetSubscriptionAsync(subscriptionId));
        }

        [Fact]
        public async Task CreateSubscriptionAsync_WithValidSubscription_ShouldReturnCreatedSubscription()
        {
            // Arrange
            Subscription subscription = new() { CustomerId = "ctm_1" };
            PaddleResponse<Subscription> expectedResponse = new()
            {
                Data = new Subscription { Id = "sub_1", CustomerId = "ctm_1" }
            };

            _mockClient
                .Setup(x => x.PostAsync<Subscription, PaddleResponse<Subscription>>("/subscriptions", subscription, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Subscription> result = await _service.CreateSubscriptionAsync(subscription);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("sub_1", result.Data.Id);
            Assert.Equal(subscription.CustomerId, result.Data.CustomerId);
        }

        [Fact]
        public async Task CreateSubscriptionAsync_WithNullSubscription_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateSubscriptionAsync(null));
        }

        [Fact]
        public async Task UpdateSubscriptionAsync_WithValidSubscription_ShouldReturnUpdatedSubscription()
        {
            // Arrange
            string subscriptionId = "sub_1";
            Subscription subscription = new() { CustomerId = "ctm_1" };
            PaddleResponse<Subscription> expectedResponse = new()
            {
                Data = new Subscription { Id = subscriptionId, CustomerId = "ctm_1" }
            };

            _mockClient
                .Setup(x => x.PatchAsync<Subscription, PaddleResponse<Subscription>>($"/subscriptions/{subscriptionId}", subscription, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Subscription> result = await _service.UpdateSubscriptionAsync(subscriptionId, subscription);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(subscriptionId, result.Data.Id);
            Assert.Equal(subscription.CustomerId, result.Data.CustomerId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task UpdateSubscriptionAsync_WithInvalidId_ShouldThrowArgumentException(string subscriptionId)
        {
            // Arrange
            Subscription subscription = new() { CustomerId = "ctm_1" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateSubscriptionAsync(subscriptionId, subscription));
        }

        [Fact]
        public async Task UpdateSubscriptionAsync_WithNullSubscription_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateSubscriptionAsync("sub_1", null));
        }

        [Fact]
        public async Task ListCustomerSubscriptionsAsync_WithValidCustomerId_ShouldReturnSubscriptions()
        {
            // Arrange
            string customerId = "ctm_1";
            PaddleResponse<List<Subscription>> expectedResponse = new()
            {
                Data = new List<Subscription>
                {
                    new() { Id = "sub_1", CustomerId = customerId },
                    new() { Id = "sub_2", CustomerId = customerId }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Subscription>>>($"/subscriptions?customer_id={customerId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Subscription>> result = await _service.ListCustomerSubscriptionsAsync(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.All(result.Data, sub => Assert.Equal(customerId, sub.CustomerId));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ListCustomerSubscriptionsAsync_WithInvalidCustomerId_ShouldThrowArgumentException(string customerId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListCustomerSubscriptionsAsync(customerId));
        }

        [Fact]
        public async Task PauseSubscriptionAsync_WithValidId_ShouldReturnPausedSubscription()
        {
            // Arrange
            string subscriptionId = "sub_1";
            PaddleResponse<Subscription> expectedResponse = new()
            {
                Data = new Subscription { Id = subscriptionId, Status = "paused" }
            };

            _mockClient
                .Setup(x => x.PostAsync<object, PaddleResponse<Subscription>>($"/subscriptions/{subscriptionId}/pause", null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Subscription> result = await _service.PauseSubscriptionAsync(subscriptionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("paused", result.Data.Status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task PauseSubscriptionAsync_WithInvalidId_ShouldThrowArgumentException(string subscriptionId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.PauseSubscriptionAsync(subscriptionId));
        }

        [Fact]
        public async Task ResumeSubscriptionAsync_WithValidId_ShouldReturnResumedSubscription()
        {
            // Arrange
            string subscriptionId = "sub_1";
            PaddleResponse<Subscription> expectedResponse = new()
            {
                Data = new Subscription { Id = subscriptionId, Status = "active" }
            };

            _mockClient
                .Setup(x => x.PostAsync<object, PaddleResponse<Subscription>>($"/subscriptions/{subscriptionId}/resume", null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Subscription> result = await _service.ResumeSubscriptionAsync(subscriptionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("active", result.Data.Status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ResumeSubscriptionAsync_WithInvalidId_ShouldThrowArgumentException(string subscriptionId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ResumeSubscriptionAsync(subscriptionId));
        }

        [Fact]
        public async Task CancelSubscriptionAsync_WithValidId_ShouldReturnCanceledSubscription()
        {
            // Arrange
            string subscriptionId = "sub_1";
            PaddleResponse<Subscription> expectedResponse = new()
            {
                Data = new Subscription { Id = subscriptionId, Status = "canceled" }
            };

            _mockClient
                .Setup(x => x.PostAsync<object, PaddleResponse<Subscription>>($"/subscriptions/{subscriptionId}/cancel", null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Subscription> result = await _service.CancelSubscriptionAsync(subscriptionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("canceled", result.Data.Status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task CancelSubscriptionAsync_WithInvalidId_ShouldThrowArgumentException(string subscriptionId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.CancelSubscriptionAsync(subscriptionId));
        }
    }
}