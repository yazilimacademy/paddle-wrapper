using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Adjustments;

public class AdjustmentTaxRatesUsed
{
    [JsonPropertyName("tax_rate")]
    public string TaxRate { get; }

    [JsonPropertyName("totals")]
    public AdjustmentTaxRatesUsedTotals Totals { get; }

    private AdjustmentTaxRatesUsed(string taxRate, AdjustmentTaxRatesUsedTotals totals)
    {
        TaxRate = taxRate;
        Totals = totals;
    }

    public static AdjustmentTaxRatesUsed FromJson(JsonElement data)
    {
        return new AdjustmentTaxRatesUsed(
            data.GetProperty("tax_rate").GetString()!,
            AdjustmentTaxRatesUsedTotals.FromJson(data.GetProperty("totals"))
        );
    }
}