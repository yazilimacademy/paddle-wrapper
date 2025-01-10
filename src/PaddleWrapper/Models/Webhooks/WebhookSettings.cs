using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PaddleWrapper.Models.Webhooks
{
    /// <summary>
    /// Represents webhook settings for Paddle
    /// </summary>
    public class WebhookSettings
    {
        /// <summary>
        /// The type of notification settings (always "webhook")
        /// </summary>
        [JsonProperty("type")]
        [Required(ErrorMessage = "The type field is required")]
        public string Type { get; set; } = "webhook";

        /// <summary>
        /// Description of the webhook endpoint
        /// </summary>
        [JsonProperty("description")]
        [Required(ErrorMessage = "The description field is required")]
        public string Description { get; set; }

        /// <summary>
        /// The destination URL where webhooks will be sent
        /// </summary>
        [JsonProperty("destination")]
        [Required(ErrorMessage = "The destination field is required")]
        [Url(ErrorMessage = "The destination must be a valid URL")]
        public string Destination { get; set; }

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
        [Required(ErrorMessage = "The subscribed events field is required")]
        [MinLength(1, ErrorMessage = "At least one subscribed event is required")]
        public string[] SubscribedEvents { get; set; }
    }
}