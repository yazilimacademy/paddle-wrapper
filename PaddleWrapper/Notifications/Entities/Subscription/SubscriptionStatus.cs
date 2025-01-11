using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscription;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionStatus
{
    [JsonPropertyName("active")]
    Active,

    [JsonPropertyName("canceled")]
    Canceled,

    [JsonPropertyName("past_due")]
    PastDue,

    [JsonPropertyName("paused")]
    Paused,

    [JsonPropertyName("trialing")]
    Trialing,

    [JsonPropertyName("inactive")]
    Inactive
} 