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
        string amount = element.GetProperty("amount").GetString()!;
        CurrencyCode? currencyCode = null;

        if (element.TryGetProperty("currency_code", out JsonElement code))
        {
            string? codeStr = code.GetString();
            if (!string.IsNullOrEmpty(codeStr))
            {
                currencyCode = JsonSerializer.Deserialize<CurrencyCode>(code.GetRawText());
            }
        }

        return new Money(amount, currencyCode);
    }
}