using System.Text.Json.Serialization;

namespace PaddleWrapper.Responses
{
    internal class ApiResponse<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}