using System.Text.Json;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionPreviewDetails
    {
        public TaxRatesUsed[] TaxRatesUsed { get; }
        public TransactionPreviewTotals Totals { get; }

        public TransactionPreviewDetails(TaxRatesUsed[] taxRatesUsed, TransactionPreviewTotals totals)
        {
            TaxRatesUsed = taxRatesUsed;
            Totals = totals;
        }

        public static TransactionPreviewDetails FromDict(JsonElement data)
        {
            var taxRatesUsed = data.GetProperty("tax_rates_used").EnumerateArray()
                .Select(TaxRatesUsed.FromDict)
                .ToArray();

            return new TransactionPreviewDetails(
                taxRatesUsed: taxRatesUsed,
                totals: TransactionPreviewTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 