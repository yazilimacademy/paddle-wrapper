using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionOnPaymentFailure
    {
        [EnumMember(Value = "prevent_change")]
        PreventChange,

        [EnumMember(Value = "apply_change")]
        ApplyChange
    }
}