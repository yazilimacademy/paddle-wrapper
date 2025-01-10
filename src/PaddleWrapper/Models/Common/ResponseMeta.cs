using Newtonsoft.Json;

namespace PaddleWrapper.Models.Common
{
    /// <summary>
    /// Represents metadata in API responses
    /// </summary>
    public class ResponseMeta
    {
        /// <summary>
        /// The request ID for tracking purposes
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// Pagination information if the response is paginated
        /// </summary>
        [JsonProperty("pagination")]
        public PaginationMeta Pagination { get; set; }
    }
}