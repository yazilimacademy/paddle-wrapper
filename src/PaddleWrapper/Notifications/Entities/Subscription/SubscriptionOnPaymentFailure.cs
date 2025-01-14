using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscriptions;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionOnPaymentFailure
{
    [JsonPropertyName("prevent_change")]
    PreventChange,

    [JsonPropertyName("apply_change")]
    ApplyChange
}