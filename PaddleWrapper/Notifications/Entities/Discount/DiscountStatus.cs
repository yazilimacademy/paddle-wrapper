using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Discount;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DiscountStatus
{
    [JsonPropertyName("active")]
    Active,

    [JsonPropertyName("archived")]
    Archived,

    [JsonPropertyName("expired")]
    Expired,

    [JsonPropertyName("used")]
    Used
} 