using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CurrencyCodePayouts
{
    [JsonPropertyName("AUD")]
    AUD,
    [JsonPropertyName("CAD")]
    CAD,
    [JsonPropertyName("CHF")]
    CHF,
    [JsonPropertyName("CNY")]
    CNY,
    [JsonPropertyName("CZK")]
    CZK,
    [JsonPropertyName("DKK")]
    DKK,
    [JsonPropertyName("EUR")]
    EUR,
    [JsonPropertyName("GBP")]
    GBP,
    [JsonPropertyName("HUF")]
    HUF,
    [JsonPropertyName("PLN")]
    PLN,
    [JsonPropertyName("SEK")]
    SEK,
    [JsonPropertyName("USD")]
    USD,
    [JsonPropertyName("ZAR")]
    ZAR
}