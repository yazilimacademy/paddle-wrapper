using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscriptions;

public class SubscriptionScheduledChange
{
    [JsonPropertyName("action")]
    public SubscriptionScheduledChangeAction Action { get; set; }

    [JsonPropertyName("effective_at")]
    public DateTime? EffectiveAt { get; set; }

    [JsonPropertyName("resume_at")]
    public DateTime? ResumeAt { get; set; }

    public static SubscriptionScheduledChange FromJson(JsonElement data)
    {
        return new SubscriptionScheduledChange
        {
            Action = JsonSerializer.Deserialize<SubscriptionScheduledChangeAction>(data.GetProperty("action").GetRawText()),
            EffectiveAt = data.TryGetProperty("effective_at", out var effectiveAt) && !effectiveAt.ValueKind.Equals(JsonValueKind.Null)
                ? DateTime.Parse(effectiveAt.GetString()!)
                : null,
            ResumeAt = data.TryGetProperty("resume_at", out var resumeAt) && !resumeAt.ValueKind.Equals(JsonValueKind.Null)
                ? DateTime.Parse(resumeAt.GetString()!)
                : null
        };
    }
} 