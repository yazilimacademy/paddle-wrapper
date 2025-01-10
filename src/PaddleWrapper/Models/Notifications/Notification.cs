using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Notifications
{
    /// <summary>
    /// Represents a notification in the Paddle system
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// The unique identifier for the notification
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of notification (e.g., subscription.created, transaction.completed)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The status of the notification (unread, read)
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The type of entity this notification is about
        /// </summary>
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        /// <summary>
        /// The ID of the entity this notification is about
        /// </summary>
        [JsonProperty("entity_id")]
        public string EntityId { get; set; }

        /// <summary>
        /// The event that triggered this notification
        /// </summary>
        [JsonProperty("event")]
        public string Event { get; set; }

        /// <summary>
        /// The data associated with this notification
        /// </summary>
        [JsonProperty("data")]
        public NotificationData Data { get; set; }

        /// <summary>
        /// When the notification was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the notification was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// When the notification was read (if applicable)
        /// </summary>
        [JsonProperty("read_at")]
        public DateTime? ReadAt { get; set; }
    }
}