using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionDetails
    {
        [JsonPropertyName("tax_rates_used")]
        public IReadOnlyList<TaxRatesUsed> TaxRatesUsed { get; }

        [JsonPropertyName("totals")]
        public TransactionTotals Totals { get; }

        [JsonPropertyName("adjusted_totals")]
        public TransactionTotalsAdjusted? AdjustedTotals { get; }

        [JsonPropertyName("payout_totals")]
        public TransactionPayoutTotals? PayoutTotals { get; }

        [JsonPropertyName("adjusted_payout_totals")]
        public TransactionPayoutTotalsAdjusted? AdjustedPayoutTotals { get; }

        [JsonPropertyName("line_items")]
        public IReadOnlyList<TransactionLineItem> LineItems { get; }

        private TransactionDetails(
            IReadOnlyList<TaxRatesUsed> taxRatesUsed,
            TransactionTotals totals,
            TransactionTotalsAdjusted? adjustedTotals,
            TransactionPayoutTotals? payoutTotals,
            TransactionPayoutTotalsAdjusted? adjustedPayoutTotals,
            IReadOnlyList<TransactionLineItem> lineItems)
        {
            TaxRatesUsed = taxRatesUsed;
            Totals = totals;
            AdjustedTotals = adjustedTotals;
            PayoutTotals = payoutTotals;
            AdjustedPayoutTotals = adjustedPayoutTotals;
            LineItems = lineItems;
        }

        public static TransactionDetails From(Dictionary<string, object> data)
        {
            List<TaxRatesUsed> taxRatesUsed = new();
            object[] taxRatesUsedData = (object[])data["tax_rates_used"];
            foreach (object item in taxRatesUsedData)
            {
                taxRatesUsed.Add(Shared.TaxRatesUsed.From((Dictionary<string, object>)item));
            }

            List<TransactionLineItem> lineItems = new();
            object[] lineItemsData = (object[])data["line_items"];
            foreach (object item in lineItemsData)
            {
                lineItems.Add(TransactionLineItem.From((Dictionary<string, object>)item));
            }

            return new TransactionDetails(
                taxRatesUsed: taxRatesUsed,
                totals: TransactionTotals.From((Dictionary<string, object>)data["totals"]),
                adjustedTotals: data.ContainsKey("adjusted_totals") ? TransactionTotalsAdjusted.From((Dictionary<string, object>)data["adjusted_totals"]) : null,
                payoutTotals: data.ContainsKey("payout_totals") ? TransactionPayoutTotals.From((Dictionary<string, object>)data["payout_totals"]) : null,
                adjustedPayoutTotals: data.ContainsKey("adjusted_payout_totals") ? TransactionPayoutTotalsAdjusted.From((Dictionary<string, object>)data["adjusted_payout_totals"]) : null,
                lineItems: lineItems
            );
        }
    }
}