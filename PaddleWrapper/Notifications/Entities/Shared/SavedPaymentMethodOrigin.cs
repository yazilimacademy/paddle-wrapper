using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SavedPaymentMethodOrigin
{
    [JsonPropertyName("saved_during_purchase")]
    SavedDuringPurchase,
    [JsonPropertyName("subscription")]
    Subscription
}