using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Adjustments
{
    public class AdjustmentTaxRatesUsed
    {
        [JsonPropertyName("tax_rate")]
        public string TaxRate { get; }

        [JsonPropertyName("totals")]
        public AdjustmentTaxRatesUsedTotals Totals { get; }

        [JsonConstructor]
        public AdjustmentTaxRatesUsed(string taxRate, AdjustmentTaxRatesUsedTotals totals)
        {
            TaxRate = taxRate;
            Totals = totals;
        }

        public static AdjustmentTaxRatesUsed From(Dictionary<string, object> data)
        {
            return new AdjustmentTaxRatesUsed(
                data["tax_rate"].ToString(),
                AdjustmentTaxRatesUsedTotals.From((Dictionary<string, object>)data["totals"])
            );
        }
    }
}