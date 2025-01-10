using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Notifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for managing notifications in the Paddle system
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Gets a list of all notifications
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Notification>>> ListNotificationsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a notification by its ID
        /// </summary>
        /// <param name="notificationId">The ID of the notification</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Notification>> GetNotificationAsync(string notificationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets notifications for a specific entity type
        /// </summary>
        /// <param name="entityType">The type of entity (e.g., "subscription", "transaction")</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Notification>>> ListEntityNotificationsAsync(string entityType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets notifications for a specific entity
        /// </summary>
        /// <param name="entityType">The type of entity</param>
        /// <param name="entityId">The ID of the entity</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Notification>>> ListEntityNotificationsAsync(string entityType, string entityId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Marks a notification as read
        /// </summary>
        /// <param name="notificationId">The ID of the notification</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Notification>> MarkAsReadAsync(string notificationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Marks all notifications as read
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Notification>>> MarkAllAsReadAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets unread notifications
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Notification>>> ListUnreadNotificationsAsync(CancellationToken cancellationToken = default);
    }
}