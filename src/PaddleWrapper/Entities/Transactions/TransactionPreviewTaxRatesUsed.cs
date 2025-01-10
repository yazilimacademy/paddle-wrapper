using System.Text.Json;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionPreviewTaxRatesUsed
    {
        public string TaxRate { get; }
        public TransactionPreviewTotals Totals { get; }

        public TransactionPreviewTaxRatesUsed(string taxRate, TransactionPreviewTotals totals)
        {
            TaxRate = taxRate;
            Totals = totals;
        }

        public static TransactionPreviewTaxRatesUsed FromDict(JsonElement data)
        {
            return new TransactionPreviewTaxRatesUsed(
                taxRate: data.GetProperty("tax_rate").GetString(),
                totals: TransactionPreviewTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 