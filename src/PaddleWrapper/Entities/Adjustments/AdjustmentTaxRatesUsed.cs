using System.Text.Json;

namespace PaddleWrapper.Entities.Adjustments
{
    public class AdjustmentTaxRatesUsed
    {
        public string TaxRate { get; }
        public AdjustmentTotals Totals { get; }

        public AdjustmentTaxRatesUsed(string taxRate, AdjustmentTotals totals)
        {
            TaxRate = taxRate;
            Totals = totals;
        }

        public static AdjustmentTaxRatesUsed FromDict(JsonElement data)
        {
            return new AdjustmentTaxRatesUsed(
                data.GetProperty("tax_rate").GetString(),
                AdjustmentTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 