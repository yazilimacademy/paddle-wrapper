using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaddleWrapper.Core.Models
{
    public class PaddleApiResponse
    {
        [JsonProperty("data")]
        public JArray Data { get; set; }

        [JsonProperty("meta")]
        public JObject Meta { get; set; }
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
}