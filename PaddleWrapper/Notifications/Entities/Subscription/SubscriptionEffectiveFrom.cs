using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscription;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionEffectiveFrom
{
    [JsonPropertyName("next_billing_period")]
    NextBillingPeriod,

    [JsonPropertyName("immediately")]
    Immediately
} 