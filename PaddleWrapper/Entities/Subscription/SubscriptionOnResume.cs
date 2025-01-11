using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionOnResume
    {
        [EnumMember(Value = "continue_existing_billing_period")]
        ContinueExistingBillingPeriod,

        [EnumMember(Value = "start_new_billing_period")]
        StartNewBillingPeriod
    }
} 