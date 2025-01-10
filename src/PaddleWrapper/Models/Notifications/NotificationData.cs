using Newtonsoft.Json;

namespace PaddleWrapper.Models.Notifications
{
    /// <summary>
    /// Represents the data associated with a notification
    /// </summary>
    public class NotificationData
    {
        /// <summary>
        /// The previous state of the entity (if applicable)
        /// </summary>
        [JsonProperty("previous")]
        public object Previous { get; set; }

        /// <summary>
        /// The current state of the entity
        /// </summary>
        [JsonProperty("current")]
        public object Current { get; set; }

        /// <summary>
        /// Any additional data associated with the notification
        /// </summary>
        [JsonProperty("additional")]
        public object Additional { get; set; }

        /// <summary>
        /// The origin of the notification
        /// </summary>
        [JsonProperty("origin")]
        public string Origin { get; set; }

        /// <summary>
        /// The reason for the notification (if applicable)
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}