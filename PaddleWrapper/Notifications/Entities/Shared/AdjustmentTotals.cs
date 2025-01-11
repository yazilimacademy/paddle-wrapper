using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class AdjustmentTotals
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; set; }

    [JsonPropertyName("tax")]
    public string Tax { get; set; }

    [JsonPropertyName("total")]
    public string Total { get; set; }

    [JsonPropertyName("fee")]
    public string Fee { get; set; }

    [JsonPropertyName("earnings")]
    public string Earnings { get; set; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode CurrencyCode { get; set; }

    public static AdjustmentTotals FromJson(JsonElement data)
    {
        return new AdjustmentTotals
        {
            Subtotal = data.GetProperty("subtotal").GetString()!,
            Tax = data.GetProperty("tax").GetString()!,
            Total = data.GetProperty("total").GetString()!,
            Fee = data.GetProperty("fee").GetString()!,
            Earnings = data.GetProperty("earnings").GetString()!,
            CurrencyCode = JsonSerializer.Deserialize<CurrencyCode>(data.GetProperty("currency_code").GetRawText())
        };
    }
} 