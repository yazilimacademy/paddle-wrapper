using PaddleWrapper.Entities.Subscriptions;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Subscriptions.Operations.Update
{
    public class SubscriptionDiscount
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("effective_from")]
        public string EffectiveFrom { get; }

        public SubscriptionDiscount(string id, SubscriptionEffectiveFrom effectiveFrom)
        {
            Id = id;
            EffectiveFrom = effectiveFrom.ToString().ToLower();
        }
    }
}