using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Adjustments;

public class AdjustmentTaxRatesUsedTotals
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; }

    [JsonPropertyName("tax")]
    public string Tax { get; }

    [JsonPropertyName("total")]
    public string Total { get; }

    private AdjustmentTaxRatesUsedTotals(string subtotal, string tax, string total)
    {
        Subtotal = subtotal;
        Tax = tax;
        Total = total;
    }

    public static AdjustmentTaxRatesUsedTotals FromJson(JsonElement data)
    {
        return new AdjustmentTaxRatesUsedTotals(
            data.GetProperty("subtotal").GetString()!,
            data.GetProperty("tax").GetString()!,
            data.GetProperty("total").GetString()!
        );
    }
} 