using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CurrencyCodeAdjustments
{
    [JsonPropertyName("EUR")]
    EUR,
    [JsonPropertyName("GBP")]
    GBP,
    [JsonPropertyName("USD")]
    USD
} 