using PaddleWrapper.Entities.Subscriptions;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Subscriptions.Operations
{
    public class PauseSubscription
    {
        [JsonPropertyName("effective_from")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EffectiveFrom { get; }

        [JsonPropertyName("resume_at")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResumeAt { get; }

        [JsonPropertyName("on_resume")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OnResume { get; }

        public PauseSubscription(
            SubscriptionEffectiveFrom? effectiveFrom = null,
            DateTime? resumeAt = null,
            SubscriptionOnResume? onResume = null)
        {
            EffectiveFrom = effectiveFrom?.ToString()?.ToLower();
            ResumeAt = resumeAt?.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            OnResume = onResume?.ToString()?.ToLower();
        }
    }
}