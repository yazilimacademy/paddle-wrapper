using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionItemPreviewWithPriceId
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("include_in_totals")]
        public bool? IncludeInTotals { get; }

        private TransactionItemPreviewWithPriceId(
            string priceId,
            int quantity,
            bool? includeInTotals)
        {
            PriceId = priceId;
            Quantity = quantity;
            IncludeInTotals = includeInTotals;
        }

        public static TransactionItemPreviewWithPriceId From(Dictionary<string, object> data)
        {
            return new TransactionItemPreviewWithPriceId(
                priceId: (string)data["price_id"],
                quantity: (int)data["quantity"],
                includeInTotals: data.ContainsKey("include_in_totals") ? (bool?)data["include_in_totals"] : null
            );
        }
    }
}