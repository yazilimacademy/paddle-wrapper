using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Events.Webhooks
{
    /// <summary>
    /// Represents a webhook event from Paddle
    /// </summary>
    public class WebhookEvent
    {
        /// <summary>
        /// The unique identifier for the event
        /// </summary>
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        /// <summary>
        /// The type of event
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        /// <summary>
        /// When the event occurred
        /// </summary>
        [JsonProperty("occurred_at")]
        public DateTime OccurredAt { get; set; }

        /// <summary>
        /// The data associated with the event
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}