using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionUpdateItem
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        private SubscriptionUpdateItem(
            string priceId,
            int quantity)
        {
            PriceId = priceId;
            Quantity = quantity;
        }

        public static SubscriptionUpdateItem From(Dictionary<string, object> data)
        {
            return new SubscriptionUpdateItem(
                priceId: (string)data["price_id"],
                quantity: (int)data["quantity"]
            );
        }
    }
} 