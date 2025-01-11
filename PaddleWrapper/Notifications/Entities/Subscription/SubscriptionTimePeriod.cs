using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscription;

public class SubscriptionTimePeriod
{
    [JsonPropertyName("starts_at")]
    public DateTime StartsAt { get; set; }

    [JsonPropertyName("ends_at")]
    public DateTime EndsAt { get; set; }

    public static SubscriptionTimePeriod FromJson(JsonElement data)
    {
        return new SubscriptionTimePeriod
        {
            StartsAt = DateTime.Parse(data.GetProperty("starts_at").GetString()!),
            EndsAt = DateTime.Parse(data.GetProperty("ends_at").GetString()!)
        };
    }
} 