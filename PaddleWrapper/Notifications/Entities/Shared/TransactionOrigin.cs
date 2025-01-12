using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionOrigin
{
    [JsonPropertyName("api")]
    Api,
    [JsonPropertyName("subscription_charge")]
    SubscriptionCharge,
    [JsonPropertyName("subscription_payment_method_change")]
    SubscriptionPaymentMethodChange,
    [JsonPropertyName("subscription_recurring")]
    SubscriptionRecurring,
    [JsonPropertyName("subscription_update")]
    SubscriptionUpdate,
    [JsonPropertyName("web")]
    Web
}