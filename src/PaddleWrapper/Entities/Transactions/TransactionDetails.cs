using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionDetails
    {
        public TaxRatesUsed[] TaxRatesUsed { get; }
        public TransactionTotals Totals { get; }

        public TransactionDetails(TaxRatesUsed[] taxRatesUsed, TransactionTotals totals)
        {
            TaxRatesUsed = taxRatesUsed;
            Totals = totals;
        }

        public static TransactionDetails FromDict(JsonElement data)
        {
            var taxRatesUsed = data.GetProperty("tax_rates_used").EnumerateArray()
                .Select(TaxRatesUsed.FromDict)
                .ToArray();

            return new TransactionDetails(
                taxRatesUsed: taxRatesUsed,
                totals: TransactionTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 