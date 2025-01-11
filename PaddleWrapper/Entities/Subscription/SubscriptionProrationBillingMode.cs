using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionProrationBillingMode
    {
        [EnumMember(Value = "prorated_immediately")]
        ProratedImmediately,

        [EnumMember(Value = "prorated_next_billing_period")]
        ProratedNextBillingPeriod,

        [EnumMember(Value = "full_immediately")]
        FullImmediately,

        [EnumMember(Value = "full_next_billing_period")]
        FullNextBillingPeriod,

        [EnumMember(Value = "do_not_bill")]
        DoNotBill
    }
} 