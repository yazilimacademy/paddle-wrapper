using PaddleWrapper.Resources.Transactions.Operations.Price;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations.Update
{
    public class TransactionUpdateItemWithPrice
    {
        [JsonPropertyName("price")]
        public object Price { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        public TransactionUpdateItemWithPrice(object price, int quantity)
        {
            if (price is not TransactionNonCatalogPrice and not TransactionNonCatalogPriceWithProduct)
            {
                throw new System.ArgumentException("Price must be either TransactionNonCatalogPrice or TransactionNonCatalogPriceWithProduct", nameof(price));
            }

            Price = price;
            Quantity = quantity;
        }
    }
}