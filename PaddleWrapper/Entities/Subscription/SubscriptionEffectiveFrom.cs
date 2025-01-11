using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionEffectiveFrom
    {
        [EnumMember(Value = "next_billing_period")]
        NextBillingPeriod,

        [EnumMember(Value = "immediately")]
        Immediately
    }
} 