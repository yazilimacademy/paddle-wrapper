using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscriptions;

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