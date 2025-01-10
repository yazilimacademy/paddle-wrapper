using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Notifications;
using PaddleWrapper.Services;

namespace PaddleWrapper.Tests.Services
{
    public class NotificationServiceTests
    {
        private readonly Mock<IPaddleClient> _mockClient;
        private readonly Mock<ILogger<NotificationService>> _mockLogger;
        private readonly NotificationService _service;

        public NotificationServiceTests()
        {
            _mockClient = new Mock<IPaddleClient>();
            _mockLogger = new Mock<ILogger<NotificationService>>();
            _service = new NotificationService(_mockClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListNotificationsAsync_ShouldReturnNotifications()
        {
            // Arrange
            PaddleResponse<List<Notification>> expectedResponse = new()
            {
                Data = new List<Notification>
                {
                    new() { Id = "ntf_1", Type = "subscription.created" },
                    new() { Id = "ntf_2", Type = "subscription.updated" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Notification>>>("/notifications", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Notification>> result = await _service.ListNotificationsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("ntf_1", result.Data[0].Id);
            Assert.Equal("ntf_2", result.Data[1].Id);
        }

        [Fact]
        public async Task GetNotificationAsync_WithValidId_ShouldReturnNotification()
        {
            // Arrange
            string notificationId = "ntf_1";
            PaddleResponse<Notification> expectedResponse = new()
            {
                Data = new Notification { Id = notificationId, Type = "subscription.created" }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<Notification>>($"/notifications/{notificationId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Notification> result = await _service.GetNotificationAsync(notificationId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(notificationId, result.Data.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetNotificationAsync_WithInvalidId_ShouldThrowArgumentException(string notificationId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetNotificationAsync(notificationId));
        }

        [Fact]
        public async Task ListEntityNotificationsAsync_WithValidEntityType_ShouldReturnNotifications()
        {
            // Arrange
            string entityType = "subscription";
            PaddleResponse<List<Notification>> expectedResponse = new()
            {
                Data = new List<Notification>
                {
                    new() { Id = "ntf_1", Type = "subscription.created" },
                    new() { Id = "ntf_2", Type = "subscription.updated" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Notification>>>($"/notifications?entity_type={entityType}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Notification>> result = await _service.ListEntityNotificationsAsync(entityType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ListEntityNotificationsAsync_WithInvalidEntityType_ShouldThrowArgumentException(string entityType)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListEntityNotificationsAsync(entityType));
        }

        [Fact]
        public async Task ListEntityNotificationsAsync_WithValidEntityTypeAndId_ShouldReturnNotifications()
        {
            // Arrange
            string entityType = "subscription";
            string entityId = "sub_1";
            PaddleResponse<List<Notification>> expectedResponse = new()
            {
                Data = new List<Notification>
                {
                    new() { Id = "ntf_1", Type = "subscription.created" },
                    new() { Id = "ntf_2", Type = "subscription.updated" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Notification>>>($"/notifications?entity_type={entityType}&entity_id={entityId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Notification>> result = await _service.ListEntityNotificationsAsync(entityType, entityId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
        }

        [Theory]
        [InlineData(null, "sub_1")]
        [InlineData("", "sub_1")]
        [InlineData(" ", "sub_1")]
        [InlineData("subscription", null)]
        [InlineData("subscription", "")]
        [InlineData("subscription", " ")]
        public async Task ListEntityNotificationsAsync_WithInvalidParameters_ShouldThrowArgumentException(string entityType, string entityId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListEntityNotificationsAsync(entityType, entityId));
        }

        [Fact]
        public async Task MarkAsReadAsync_WithValidId_ShouldReturnMarkedNotification()
        {
            // Arrange
            string notificationId = "ntf_1";
            PaddleResponse<Notification> expectedResponse = new()
            {
                Data = new Notification { Id = notificationId, Status = "read" }
            };

            _mockClient
                .Setup(x => x.PostAsync<object, PaddleResponse<Notification>>($"/notifications/{notificationId}/read", null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Notification> result = await _service.MarkAsReadAsync(notificationId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("read", result.Data.Status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task MarkAsReadAsync_WithInvalidId_ShouldThrowArgumentException(string notificationId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.MarkAsReadAsync(notificationId));
        }

        [Fact]
        public async Task MarkAllAsReadAsync_ShouldReturnMarkedNotifications()
        {
            // Arrange
            PaddleResponse<List<Notification>> expectedResponse = new()
            {
                Data = new List<Notification>
                {
                    new() { Id = "ntf_1", Status = "read" },
                    new() { Id = "ntf_2", Status = "read" }
                }
            };

            _mockClient
                .Setup(x => x.PostAsync<object, PaddleResponse<List<Notification>>>("/notifications/read-all", null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Notification>> result = await _service.MarkAllAsReadAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.All(result.Data, n => Assert.Equal("read", n.Status));
        }

        [Fact]
        public async Task ListUnreadNotificationsAsync_ShouldReturnUnreadNotifications()
        {
            // Arrange
            PaddleResponse<List<Notification>> expectedResponse = new()
            {
                Data = new List<Notification>
                {
                    new() { Id = "ntf_1", Status = "unread" },
                    new() { Id = "ntf_2", Status = "unread" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Notification>>>("/notifications?status=unread", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Notification>> result = await _service.ListUnreadNotificationsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.All(result.Data, n => Assert.Equal("unread", n.Status));
        }
    }
}