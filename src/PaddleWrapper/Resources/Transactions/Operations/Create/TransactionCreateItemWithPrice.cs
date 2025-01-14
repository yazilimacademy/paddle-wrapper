using PaddleWrapper.Resources.Transactions.Operations.Price;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations.Create
{
    public class TransactionCreateItemWithPrice
    {
        [JsonPropertyName("price")]
        public object Price { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        public TransactionCreateItemWithPrice(object price, int quantity)
        {
            if (price is not TransactionNonCatalogPrice and not TransactionNonCatalogPriceWithProduct)
            {
                throw new ArgumentException("Price must be either TransactionNonCatalogPrice or TransactionNonCatalogPriceWithProduct", nameof(price));
            }

            Price = price;
            Quantity = quantity;
        }
    }
}