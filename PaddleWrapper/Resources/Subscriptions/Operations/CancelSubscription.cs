using PaddleWrapper.Entities.Subscriptions;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Subscriptions.Operations
{
    public class CancelSubscription
    {
        [JsonPropertyName("effective_from")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EffectiveFrom { get; }

        public CancelSubscription(SubscriptionEffectiveFrom? effectiveFrom = null)
        {
            EffectiveFrom = effectiveFrom?.ToString()?.ToLower();
        }
    }
}