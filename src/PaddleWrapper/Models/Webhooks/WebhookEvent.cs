using Newtonsoft.Json;

namespace PaddleWrapper.Models.Webhooks
{
    /// <summary>
    /// Represents the notification settings for webhooks
    /// </summary>
    public class WebhookSettings
    {
        /// <summary>
        /// The endpoint URL where webhooks will be sent
        /// </summary>
        [JsonProperty("endpoint_url")]
        public string EndpointUrl { get; set; }

        /// <summary>
        /// Whether the webhook endpoint is active
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The API version to use for webhooks
        /// </summary>
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// The events to subscribe to
        /// </summary>
        [JsonProperty("subscribed_events")]
        public string[] SubscribedEvents { get; set; }
    }
}