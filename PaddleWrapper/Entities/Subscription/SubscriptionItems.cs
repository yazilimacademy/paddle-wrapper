using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionItems
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        private SubscriptionItems(
            string priceId,
            int quantity)
        {
            PriceId = priceId;
            Quantity = quantity;
        }

        public static SubscriptionItems From(Dictionary<string, object> data)
        {
            return new SubscriptionItems(
                priceId: (string)data["price_id"],
                quantity: (int)data["quantity"]
            );
        }
    }
}