using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Discounts;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DiscountType
{
    [JsonPropertyName("flat")]
    Flat,

    [JsonPropertyName("flat_per_seat")]
    FlatPerSeat,

    [JsonPropertyName("percentage")]
    Percentage
} 