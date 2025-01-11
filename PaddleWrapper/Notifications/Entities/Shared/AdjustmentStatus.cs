using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AdjustmentStatus
{
    [JsonPropertyName("pending_approval")]
    PendingApproval,

    [JsonPropertyName("approved")]
    Approved,

    [JsonPropertyName("rejected")]
    Rejected,

    [JsonPropertyName("reversed")]
    Reversed
} 