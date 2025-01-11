using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionOrigin
    {
        [EnumMember(Value = "api")]
        Api,

        [EnumMember(Value = "subscription_charge")]
        SubscriptionCharge,

        [EnumMember(Value = "subscription_payment_method_change")]
        SubscriptionPaymentMethodChange,

        [EnumMember(Value = "subscription_recurring")]
        SubscriptionRecurring,

        [EnumMember(Value = "subscription_update")]
        SubscriptionUpdate,

        [EnumMember(Value = "web")]
        Web
    }
} 