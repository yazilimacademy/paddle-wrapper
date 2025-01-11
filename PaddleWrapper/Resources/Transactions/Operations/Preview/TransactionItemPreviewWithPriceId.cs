using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations.Preview
{
    public class TransactionItemPreviewWithPriceId
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("include_in_totals")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeInTotals { get; }

        public TransactionItemPreviewWithPriceId(string priceId, int quantity, bool? includeInTotals = null)
        {
            PriceId = priceId;
            Quantity = quantity;
            IncludeInTotals = includeInTotals;
        }
    }
} 