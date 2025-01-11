using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Price;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionItemPreviewWithPrice
    {
        [JsonPropertyName("price")]
        public object Price { get; }  // Can be either Price or TransactionPreviewPrice

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("include_in_totals")]
        public bool IncludeInTotals { get; }

        [JsonPropertyName("proration")]
        public TransactionProration? Proration { get; }

        private TransactionItemPreviewWithPrice(
            object price,
            int quantity,
            bool includeInTotals,
            TransactionProration? proration)
        {
            Price = price;
            Quantity = quantity;
            IncludeInTotals = includeInTotals;
            Proration = proration;
        }

        public static TransactionItemPreviewWithPrice From(Dictionary<string, object> data)
        {
            var priceData = (Dictionary<string, object>)data["price"];
            object price;

            // Determine which type of price object to create based on the data
            if (priceData.ContainsKey("id") && priceData.ContainsKey("product_id"))
            {
                price = Price.Price.From(priceData);
            }
            else
            {
                price = TransactionPreviewPrice.From(priceData);
            }

            return new TransactionItemPreviewWithPrice(
                price: price,
                quantity: (int)data["quantity"],
                includeInTotals: (bool)data["include_in_totals"],
                proration: data.ContainsKey("proration") ? TransactionProration.From((Dictionary<string, object>)data["proration"]) : null
            );
        }
    }
} 