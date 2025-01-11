using System.Runtime.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations.List
{
    public enum Origin
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