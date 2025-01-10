using System.Text.Json;

namespace PaddleWrapper.Entities.Transactions
{
    public class TaxRatesUsed
    {
        public string TaxRate { get; }
        public TransactionTotals Totals { get; }

        public TaxRatesUsed(string taxRate, TransactionTotals totals)
        {
            TaxRate = taxRate;
            Totals = totals;
        }

        public static TaxRatesUsed FromDict(JsonElement data)
        {
            return new TaxRatesUsed(
                taxRate: data.GetProperty("tax_rate").GetString(),
                totals: TransactionTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 