using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscriptions;

public class SubscriptionDiscount
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("starts_at")]
    public DateTime? StartsAt { get; set; }

    [JsonPropertyName("ends_at")]
    public DateTime? EndsAt { get; set; }

    public static SubscriptionDiscount FromJson(JsonElement data)
    {
        return new SubscriptionDiscount
        {
            Id = data.GetProperty("id").GetString()!,
            StartsAt = data.TryGetProperty("starts_at", out JsonElement startsAt) && !startsAt.ValueKind.Equals(JsonValueKind.Null)
                ? DateTime.Parse(startsAt.GetString()!)
                : null,
            EndsAt = data.TryGetProperty("ends_at", out JsonElement endsAt) && !endsAt.ValueKind.Equals(JsonValueKind.Null)
                ? DateTime.Parse(endsAt.GetString()!)
                : null
        };
    }
}