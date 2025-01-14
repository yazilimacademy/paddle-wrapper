using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Subscriptions.Operations.Update;

public class ScheduledChange
{
    [JsonPropertyName("action")]
    public string Action { get; set; }

    [JsonPropertyName("effective_at")]
    public DateTime EffectiveAt { get; set; }

    [JsonPropertyName("resume_at")]
    public DateTime? ResumeAt { get; set; }

    public ScheduledChange(string action, DateTime effectiveAt, DateTime? resumeAt = null)
    {
        Action = action;
        EffectiveAt = effectiveAt;
        ResumeAt = resumeAt;
    }
}