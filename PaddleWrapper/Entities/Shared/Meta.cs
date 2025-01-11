using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Meta
    {
        [JsonPropertyName("request_id")]
        public string RequestId { get; }

        [JsonConstructor]
        public Meta(string requestId)
        {
            RequestId = requestId;
        }

        public static Meta From(Dictionary<string, object> data)
        {
            return new Meta(
                requestId: data["request_id"].ToString()
            );
        }
    }
} 