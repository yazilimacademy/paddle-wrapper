using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionDetails
    {
        [JsonPropertyName("tax_rate_used")]
        public IReadOnlyList<TaxRatesUsed> TaxRatesUsed { get; }

        [JsonPropertyName("transaction_totals")]
        public TransactionTotals Totals { get; }

        [JsonPropertyName("transaction_totals_adjusted")]
        public TransactionTotalsAdjusted AdjustedTotals { get; }

        [JsonPropertyName("transaction_payout_totals")]
        public TransactionPayoutTotals PayoutTotals { get; }

        [JsonPropertyName("transaction_payout_totals_adjusted")]
        public TransactionPayoutTotalsAdjusted AdjustedPayoutTotals { get; }

        [JsonPropertyName("line_items")]
        public IReadOnlyList<SubscriptionTransactionLineItem> LineItems { get; }

        private SubscriptionDetails(
            IReadOnlyList<TaxRatesUsed> taxRatesUsed,
            TransactionTotals totals,
            TransactionTotalsAdjusted adjustedTotals,
            TransactionPayoutTotals payoutTotals,
            TransactionPayoutTotalsAdjusted adjustedPayoutTotals,
            IReadOnlyList<SubscriptionTransactionLineItem> lineItems)
        {
            TaxRatesUsed = taxRatesUsed;
            Totals = totals;
            AdjustedTotals = adjustedTotals;
            PayoutTotals = payoutTotals;
            AdjustedPayoutTotals = adjustedPayoutTotals;
            LineItems = lineItems;
        }

        public static SubscriptionDetails From(Dictionary<string, object> data)
        {
            var taxRatesUsed = new List<TaxRatesUsed>();
            if (data.ContainsKey("tax_rate_used"))
            {
                var taxRatesData = (object[])data["tax_rate_used"];
                foreach (var item in taxRatesData)
                {
                    taxRatesUsed.Add(TaxRatesUsed.From((Dictionary<string, object>)item));
                }
            }

            var lineItems = new List<SubscriptionTransactionLineItem>();
            if (data.ContainsKey("line_items"))
            {
                var lineItemsData = (object[])data["line_items"];
                foreach (var item in lineItemsData)
                {
                    lineItems.Add(SubscriptionTransactionLineItem.From((Dictionary<string, object>)item));
                }
            }

            return new SubscriptionDetails(
                taxRatesUsed: taxRatesUsed,
                totals: TransactionTotals.From((Dictionary<string, object>)data["transaction_totals"]),
                adjustedTotals: TransactionTotalsAdjusted.From((Dictionary<string, object>)data["transaction_totals_adjusted"]),
                payoutTotals: TransactionPayoutTotals.From((Dictionary<string, object>)data["transaction_payout_totals"]),
                adjustedPayoutTotals: TransactionPayoutTotalsAdjusted.From((Dictionary<string, object>)data["transaction_payout_totals_adjusted"]),
                lineItems: lineItems
            );
        }
    }
} 