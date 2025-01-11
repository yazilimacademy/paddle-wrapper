using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Pagination
    {
        [JsonPropertyName("per_page")]
        public int PerPage { get; }

        [JsonPropertyName("next")]
        public string Next { get; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; }

        [JsonPropertyName("estimated_total")]
        public int EstimatedTotal { get; }

        [JsonConstructor]
        public Pagination(int perPage, string next, bool hasMore, int estimatedTotal)
        {
            PerPage = perPage;
            Next = next;
            HasMore = hasMore;
            EstimatedTotal = estimatedTotal;
        }

        public static Pagination From(Dictionary<string, object> data)
        {
            return new Pagination(
                perPage: (int)data["per_page"],
                next: data["next"].ToString(),
                hasMore: (bool)data["has_more"],
                estimatedTotal: (int)data["estimated_total"]
            );
        }
    }
} 