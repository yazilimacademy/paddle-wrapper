using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Transactions;

public class TransactionTimePeriod
{
    [JsonPropertyName("starts_at")]
    public DateTime? StartsAt { get; set; }

    [JsonPropertyName("ends_at")]
    public DateTime? EndsAt { get; set; }

    public static TransactionTimePeriod FromJson(JsonElement data)
    {
        return new TransactionTimePeriod
        {
            StartsAt = data.TryGetProperty("starts_at", out var startsAt) && !startsAt.ValueKind.Equals(JsonValueKind.Null)
                ? DateTime.Parse(startsAt.GetString()!)
                : null,
            EndsAt = data.TryGetProperty("ends_at", out var endsAt) && !endsAt.ValueKind.Equals(JsonValueKind.Null)
                ? DateTime.Parse(endsAt.GetString()!)
                : null
        };
    }
} 