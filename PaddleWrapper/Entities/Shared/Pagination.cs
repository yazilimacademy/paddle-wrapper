using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Pagination
    {
        [JsonPropertyName("per_page")]
        public int PerPage { get; }

        [JsonPropertyName("next")]
        public string? Next { get; }

        [JsonPropertyName("previous")]
        public string? Previous { get; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; }

        [JsonPropertyName("estimated_total")]
        public int EstimatedTotal { get; }

        [JsonConstructor]
        public Pagination(int perPage, string? next, string? previous, bool hasMore, int estimatedTotal)
        {
            PerPage = perPage;
            Next = next;
            Previous = previous;
            HasMore = hasMore;
            EstimatedTotal = estimatedTotal;
        }

        public static Pagination FromJson(JsonElement json)
        {
            return new Pagination(
                perPage: json.TryGetProperty("per_page", out JsonElement perPage) ? perPage.GetInt32() : 10,
                next: json.TryGetProperty("next", out JsonElement next) && next.ValueKind != JsonValueKind.Null ? next.GetString() : null,
                previous: json.TryGetProperty("previous", out JsonElement previous) && previous.ValueKind != JsonValueKind.Null ? previous.GetString() : null,
                hasMore: json.TryGetProperty("has_more", out JsonElement hasMore) && hasMore.GetBoolean(),
                estimatedTotal: json.TryGetProperty("estimated_total", out JsonElement estimatedTotal) ? estimatedTotal.GetInt32() : 0
            );
        }

        public static Pagination From(Dictionary<string, object> data)
        {
            JsonElement json = JsonSerializer.SerializeToElement(data);
            return FromJson(json);
        }
    }
}