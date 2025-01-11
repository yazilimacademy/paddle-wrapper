using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscription;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionScheduledChangeAction
{
    [JsonPropertyName("cancel")]
    Cancel,

    [JsonPropertyName("pause")]
    Pause,

    [JsonPropertyName("resume")]
    Resume
} 