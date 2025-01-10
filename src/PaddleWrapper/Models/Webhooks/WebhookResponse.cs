using Newtonsoft.Json;

namespace PaddleWrapper.Models.Webhooks
{
    /// <summary>
    /// Represents a response from the Paddle webhook API
    /// </summary>
    public class WebhookResponse<T>
    {
        /// <summary>
        /// The data returned by the API
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}