using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Reports;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReportStatus
{
    [JsonPropertyName("pending")]
    Pending,

    [JsonPropertyName("ready")]
    Ready,

    [JsonPropertyName("failed")]
    Failed,

    [JsonPropertyName("expired")]
    Expired
} 