using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class MetaPaginated
    {
        [JsonPropertyName("request_id")]
        public string RequestId { get; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; }

        [JsonConstructor]
        public MetaPaginated(string requestId, Pagination pagination)
        {
            RequestId = requestId;
            Pagination = pagination;
        }

        public static MetaPaginated From(Dictionary<string, object> data)
        {
            return new MetaPaginated(
                requestId: data["request_id"].ToString(),
                pagination: Pagination.From((Dictionary<string, object>)data["pagination"])
            );
        }
    }
}