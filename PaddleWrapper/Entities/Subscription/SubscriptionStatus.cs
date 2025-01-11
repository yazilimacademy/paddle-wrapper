using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "canceled")]
        Canceled,

        [EnumMember(Value = "past_due")]
        PastDue,

        [EnumMember(Value = "paused")]
        Paused,

        [EnumMember(Value = "trialing")]
        Trialing,

        [EnumMember(Value = "inactive")]
        Inactive
    }
}