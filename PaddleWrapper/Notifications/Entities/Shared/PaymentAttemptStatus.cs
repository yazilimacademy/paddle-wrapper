using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentAttemptStatus
{
    [JsonPropertyName("authorized")]
    Authorized,
    [JsonPropertyName("authorized_flagged")]
    AuthorizedFlagged,
    [JsonPropertyName("canceled")]
    Canceled,
    [JsonPropertyName("captured")]
    Captured,
    [JsonPropertyName("error")]
    Error,
    [JsonPropertyName("action_required")]
    ActionRequired,
    [JsonPropertyName("pending_no_action_required")]
    PendingNoActionRequired,
    [JsonPropertyName("created")]
    Created,
    [JsonPropertyName("unknown")]
    Unknown,
    [JsonPropertyName("dropped")]
    Dropped
}