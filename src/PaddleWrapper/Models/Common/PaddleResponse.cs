using Newtonsoft.Json;

namespace PaddleWrapper.Models.Common
{
    /// <summary>
    /// Base class for Paddle API responses
    /// </summary>
    /// <typeparam name="T">The type of the response data</typeparam>
    public class PaddleResponse<T>
    {
        /// <summary>
        /// The response data
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        /// Response metadata
        /// </summary>
        [JsonProperty("meta")]
        public ResponseMeta Meta { get; set; }
    }
}