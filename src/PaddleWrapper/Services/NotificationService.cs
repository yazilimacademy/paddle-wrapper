using Microsoft.Extensions.Logging;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Services
{
    /// <summary>
    /// Service for managing notifications in the Paddle system
    /// </summary>
    public class NotificationService : INotificationService
    {
        private readonly IPaddleClient _client;
        private readonly ILogger<NotificationService> _logger;
        private const string BasePath = "/notifications";

        /// <summary>
        /// Creates a new instance of NotificationService
        /// </summary>
        public NotificationService(IPaddleClient client, ILogger<NotificationService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Notification>>> ListNotificationsAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving list of notifications");
            return await _client.GetAsync<PaddleResponse<List<Notification>>>(BasePath, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Notification>> GetNotificationAsync(string notificationId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(notificationId))
            {
                throw new ArgumentException("Notification ID must be provided", nameof(notificationId));
            }

            _logger.LogInformation("Retrieving notification with ID: {NotificationId}", notificationId);
            return await _client.GetAsync<PaddleResponse<Notification>>($"{BasePath}/{notificationId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Notification>>> ListEntityNotificationsAsync(string entityType, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(entityType))
            {
                throw new ArgumentException("Entity type must be provided", nameof(entityType));
            }

            _logger.LogInformation("Retrieving notifications for entity type: {EntityType}", entityType);
            return await _client.GetAsync<PaddleResponse<List<Notification>>>($"{BasePath}?entity_type={entityType}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Notification>>> ListEntityNotificationsAsync(string entityType, string entityId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(entityType))
            {
                throw new ArgumentException("Entity type must be provided", nameof(entityType));
            }

            if (string.IsNullOrWhiteSpace(entityId))
            {
                throw new ArgumentException("Entity ID must be provided", nameof(entityId));
            }

            _logger.LogInformation("Retrieving notifications for entity type: {EntityType} and ID: {EntityId}", entityType, entityId);
            return await _client.GetAsync<PaddleResponse<List<Notification>>>($"{BasePath}?entity_type={entityType}&entity_id={entityId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Notification>> MarkAsReadAsync(string notificationId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(notificationId))
            {
                throw new ArgumentException("Notification ID must be provided", nameof(notificationId));
            }

            _logger.LogInformation("Marking notification as read with ID: {NotificationId}", notificationId);
            return await _client.PostAsync<object, PaddleResponse<Notification>>($"{BasePath}/{notificationId}/read", null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Notification>>> MarkAllAsReadAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Marking all notifications as read");
            return await _client.PostAsync<object, PaddleResponse<List<Notification>>>($"{BasePath}/read-all", null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Notification>>> ListUnreadNotificationsAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving unread notifications");
            return await _client.GetAsync<PaddleResponse<List<Notification>>>($"{BasePath}?status=unread", cancellationToken);
        }
    }
}