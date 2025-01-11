using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscription;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionItemStatus
{
    [JsonPropertyName("active")]
    Active,

    [JsonPropertyName("inactive")]
    Inactive,

    [JsonPropertyName("trialing")]
    Trialing
} 