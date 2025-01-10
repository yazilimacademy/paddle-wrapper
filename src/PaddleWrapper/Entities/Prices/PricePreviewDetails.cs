using System.Text.Json;

namespace PaddleWrapper.Entities.Prices
{
    public class PricePreviewDetails
    {
        public TaxRatesUsed[] TaxRatesUsed { get; }
        public PricePreviewTotals Totals { get; }

        public PricePreviewDetails(TaxRatesUsed[] taxRatesUsed, PricePreviewTotals totals)
        {
            TaxRatesUsed = taxRatesUsed;
            Totals = totals;
        }

        public static PricePreviewDetails FromDict(JsonElement data)
        {
            var taxRatesUsed = data.GetProperty("tax_rates_used").EnumerateArray()
                .Select(TaxRatesUsed.FromDict)
                .ToArray();

            return new PricePreviewDetails(
                taxRatesUsed: taxRatesUsed,
                totals: PricePreviewTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 