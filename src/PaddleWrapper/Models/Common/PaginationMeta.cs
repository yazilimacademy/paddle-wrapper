using Newtonsoft.Json;

namespace PaddleWrapper.Models.Common
{
    /// <summary>
    /// Represents pagination metadata in API responses
    /// </summary>
    public class PaginationMeta
    {
        /// <summary>
        /// The pagination cursor to use for the next page of results
        /// </summary>
        [JsonProperty("next")]
        public string Next { get; set; }

        /// <summary>
        /// The pagination cursor to use for the previous page of results
        /// </summary>
        [JsonProperty("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// The total number of results available
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// The number of results per page
        /// </summary>
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        /// <summary>
        /// The current page number
        /// </summary>
        [JsonProperty("current_page")]
        public int? CurrentPage { get; set; }

        /// <summary>
        /// The total number of pages available
        /// </summary>
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
    }
}