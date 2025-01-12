using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class Money
{
    [JsonPropertyName("amount")]
    public string Amount { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode? CurrencyCode { get; }

    private Money(string amount, CurrencyCode? currencyCode)
    {
        Amount = amount;
        CurrencyCode = currencyCode;
    }

    public static Money FromJson(JsonElement element)
    {
        var currencyCode = element.TryGetProperty("currency_code", out JsonElement code) && !string.IsNullOrEmpty(code.GetString())
            ? JsonSerializer.Deserialize<CurrencyCode>(code.GetRawText())
            : null;

        return new Money(
            element.GetProperty("amount").GetString()!,
            currencyCode
        );
    }
}