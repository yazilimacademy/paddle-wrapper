using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class AdjustmentTimePeriod
{
    [JsonPropertyName("starts_at")]
    public DateTime StartsAt { get; set; }

    [JsonPropertyName("ends_at")]
    public DateTime EndsAt { get; set; }

    public static AdjustmentTimePeriod FromJson(JsonElement data)
    {
        return new AdjustmentTimePeriod
        {
            StartsAt = DateTime.Parse(data.GetProperty("starts_at").GetString()!),
            EndsAt = DateTime.Parse(data.GetProperty("ends_at").GetString()!)
        };
    }
} 