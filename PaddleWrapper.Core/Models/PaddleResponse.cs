using Newtonsoft.Json;

namespace PaddleWrapper.Core.Models
{
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