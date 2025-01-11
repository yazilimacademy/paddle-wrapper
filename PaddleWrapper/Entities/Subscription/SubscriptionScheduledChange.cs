using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionScheduledChange
    {
        [JsonPropertyName("action")]
        public SubscriptionScheduledChangeAction Action { get; }

        [JsonPropertyName("effective_at")]
        public DateTime EffectiveAt { get; }

        [JsonPropertyName("resume_at")]
        public DateTime? ResumeAt { get; }

        private SubscriptionScheduledChange(
            SubscriptionScheduledChangeAction action,
            DateTime effectiveAt,
            DateTime? resumeAt)
        {
            Action = action;
            EffectiveAt = effectiveAt;
            ResumeAt = resumeAt;
        }

        public static SubscriptionScheduledChange From(Dictionary<string, object> data)
        {
            return new SubscriptionScheduledChange(
                action: System.Enum.Parse<SubscriptionScheduledChangeAction>((string)data["action"], true),
                effectiveAt: DateTime.Parse((string)data["effective_at"]),
                resumeAt: data.ContainsKey("resume_at") ? DateTime.Parse((string)data["resume_at"]) : null
            );
        }
    }
}