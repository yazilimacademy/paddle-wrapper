using Newtonsoft.Json;

namespace PaddleWrapper.Core.Models
{
    public class PaddleApiResponse<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("meta")]
        public PaddleMeta Meta { get; set; }
    }

    public class PaddleResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("response")]
        public T Response { get; set; }

        [JsonProperty("error")]
        public PaddleError Error { get; set; }
    }

    public class PaddleError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class PaddleMeta
    {
        [JsonProperty("request_id")]
        public Guid RequestId { get; set; }

        [JsonProperty("pagination")]
        public PaddlePagination Pagination { get; set; }
    }

    public class PaddlePagination
    {
        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("estimated_total")]
        public long EstimatedTotal { get; set; }
    }
}