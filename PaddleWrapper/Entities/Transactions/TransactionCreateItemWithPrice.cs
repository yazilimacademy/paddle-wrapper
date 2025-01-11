using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionCreateItemWithPrice
    {
        [JsonPropertyName("price")]
        public object Price { get; }  // Can be either TransactionNonCatalogPrice or TransactionNonCatalogPriceWithProduct

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        private TransactionCreateItemWithPrice(object price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public static TransactionCreateItemWithPrice From(Dictionary<string, object> data)
        {
            Dictionary<string, object> priceData = (Dictionary<string, object>)data["price"];
            object price;

            // Determine which type of price object to create based on the data
            if (priceData.ContainsKey("product"))
            {
                price = TransactionNonCatalogPriceWithProduct.From(priceData);
            }
            else
            {
                price = TransactionNonCatalogPrice.From(priceData);
            }

            return new TransactionCreateItemWithPrice(
                price: price,
                quantity: (int)data["quantity"]
            );
        }
    }
}