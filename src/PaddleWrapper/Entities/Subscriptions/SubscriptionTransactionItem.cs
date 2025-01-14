using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionTransactionItem
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("price")]
        public Price Price { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("proration")]
        public SubscriptionProration Proration { get; }

        private SubscriptionTransactionItem(
            string priceId,
            Price price,
            int quantity,
            SubscriptionProration proration)
        {
            PriceId = priceId;
            Price = price;
            Quantity = quantity;
            Proration = proration;
        }

        public static SubscriptionTransactionItem From(Dictionary<string, object> data)
        {
            return new SubscriptionTransactionItem(
                priceId: (string)data["price_id"],
                price: Price.From((Dictionary<string, object>)data["price"]),
                quantity: (int)data["quantity"],
                proration: SubscriptionProration.From((Dictionary<string, object>)data["proration"])
            );
        }
    }
}