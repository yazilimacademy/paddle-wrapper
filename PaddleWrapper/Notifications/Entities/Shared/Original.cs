using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class Original
{
    [JsonPropertyName("amount")]
    public string Amount { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCodeAdjustments CurrencyCode { get; }

    private Original(string amount, CurrencyCodeAdjustments currencyCode)
    {
        Amount = amount;
        CurrencyCode = currencyCode;
    }

    public static Original FromJson(JsonElement element)
    {
        return new Original(
            element.GetProperty("amount").GetString()!,
            JsonSerializer.Deserialize<CurrencyCodeAdjustments>(element.GetProperty("currency_code").GetRawText())
        );
    }
} 