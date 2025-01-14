using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class TransactionDetailsPreview
    {
        [JsonPropertyName("tax_rates_used")]
        public List<TaxRatesUsed> TaxRatesUsed { get; }

        [JsonPropertyName("totals")]
        public TransactionTotals Totals { get; }

        [JsonPropertyName("line_items")]
        public List<TransactionLineItemPreview> LineItems { get; }

        [JsonConstructor]
        public TransactionDetailsPreview(
            List<TaxRatesUsed> taxRatesUsed,
            TransactionTotals totals,
            List<TransactionLineItemPreview> lineItems)
        {
            TaxRatesUsed = taxRatesUsed;
            Totals = totals;
            LineItems = lineItems;
        }

        public static TransactionDetailsPreview From(Dictionary<string, object> data)
        {
            object[] taxRatesUsedArray = (object[])data["tax_rates_used"];
            object[] lineItemsArray = (object[])data["line_items"];

            return new TransactionDetailsPreview(
                taxRatesUsed: taxRatesUsedArray.Select(item => Shared.TaxRatesUsed.From((Dictionary<string, object>)item)).ToList(),
                totals: TransactionTotals.From((Dictionary<string, object>)data["totals"]),
                lineItems: lineItemsArray.Select(item => TransactionLineItemPreview.From((Dictionary<string, object>)item)).ToList()
            );
        }
    }
}