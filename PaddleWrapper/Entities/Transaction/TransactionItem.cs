using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionItem
    {
        [JsonPropertyName("price_id")]
        public string? PriceId { get; }

        [JsonPropertyName("price")]
        public Price.Price Price { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("proration")]
        public TransactionProration? Proration { get; }

        private TransactionItem(
            string? priceId,
            Price.Price price,
            int quantity,
            TransactionProration? proration)
        {
            PriceId = priceId;
            Price = price;
            Quantity = quantity;
            Proration = proration;
        }

        public static TransactionItem From(Dictionary<string, object> data)
        {
            return new TransactionItem(
                priceId: data.ContainsKey("price_id") ? (string?)data["price_id"] : null,
                price: Price.Price.From((Dictionary<string, object>)data["price"]),
                quantity: (int)data["quantity"],
                proration: data.ContainsKey("proration") ? TransactionProration.From((Dictionary<string, object>)data["proration"]) : null
            );
        }
    }
}