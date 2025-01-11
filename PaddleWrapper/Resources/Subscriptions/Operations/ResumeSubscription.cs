using System;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Subscription;

namespace PaddleWrapper.Resources.Subscriptions.Operations
{
    public class ResumeSubscription
    {
        [JsonPropertyName("effective_from")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EffectiveFrom { get; }

        [JsonPropertyName("on_resume")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OnResume { get; }

        public ResumeSubscription(
            SubscriptionResumeEffectiveFrom? effectiveFrom = null,
            DateTime? effectiveFromDate = null,
            SubscriptionOnResume? onResume = null)
        {
            EffectiveFrom = effectiveFromDate?.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'") 
                ?? effectiveFrom?.ToString()?.ToLower();
            OnResume = onResume?.ToString()?.ToLower();
        }
    }
} 