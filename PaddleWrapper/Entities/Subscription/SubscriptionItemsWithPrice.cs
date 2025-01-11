using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionItemsWithPrice
    {
        [JsonPropertyName("price")]
        public object Price { get; }  // Can be either SubscriptionNonCatalogPrice or SubscriptionNonCatalogPriceWithProduct

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        private SubscriptionItemsWithPrice(
            object price,
            int quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public static SubscriptionItemsWithPrice From(Dictionary<string, object> data)
        {
            var priceData = (Dictionary<string, object>)data["price"];
            object price;

            // Determine which type of price object to create based on the data
            if (priceData.ContainsKey("product"))
            {
                price = SubscriptionNonCatalogPriceWithProduct.From(priceData);
            }
            else
            {
                price = SubscriptionNonCatalogPrice.From(priceData);
            }

            return new SubscriptionItemsWithPrice(
                price: price,
                quantity: (int)data["quantity"]
            );
        }
    }
} 