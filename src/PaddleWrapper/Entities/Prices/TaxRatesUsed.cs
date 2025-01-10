using System.Text.Json;

namespace PaddleWrapper.Entities.Prices
{
    public class TaxRatesUsed
    {
        public string TaxRate { get; }
        public PricePreviewTotals Totals { get; }

        public TaxRatesUsed(string taxRate, PricePreviewTotals totals)
        {
            TaxRate = taxRate;
            Totals = totals;
        }

        public static TaxRatesUsed FromDict(JsonElement data)
        {
            return new TaxRatesUsed(
                taxRate: data.GetProperty("tax_rate").GetString(),
                totals: PricePreviewTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 