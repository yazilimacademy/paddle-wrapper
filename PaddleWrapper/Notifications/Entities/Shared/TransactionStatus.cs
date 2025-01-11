using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionStatus
{
    [JsonPropertyName("draft")]
    Draft,
    [JsonPropertyName("ready")]
    Ready,
    [JsonPropertyName("billed")]
    Billed,
    [JsonPropertyName("paid")]
    Paid,
    [JsonPropertyName("completed")]
    Completed,
    [JsonPropertyName("canceled")]
    Canceled,
    [JsonPropertyName("past_due")]
    PastDue
} 