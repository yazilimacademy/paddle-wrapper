using Newtonsoft.Json;

namespace PaddleWrapper.Models.Webhooks
{
    /// <summary>
    /// Represents a request to create or update webhook settings
    /// </summary>
    public class WebhookRequest
    {
        /// <summary>
        /// The data to be sent in the request
        /// </summary>
        [JsonProperty("data")]
        public WebhookSettings Data { get; set; }
    }
}