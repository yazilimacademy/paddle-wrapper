using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Payout;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PayoutStatus
{
    [JsonPropertyName("unpaid")]
    Unpaid,

    [JsonPropertyName("paid")]
    Paid
} 