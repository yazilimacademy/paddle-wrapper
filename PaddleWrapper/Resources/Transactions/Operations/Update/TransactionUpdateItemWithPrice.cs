using System.Text.Json.Serialization;
using PaddleWrapper.Resources.Transactions.Operations.Price;

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
            if (price is not TransactionNonCatalogPrice && price is not TransactionNonCatalogPriceWithProduct)
            {
                throw new System.ArgumentException("Price must be either TransactionNonCatalogPrice or TransactionNonCatalogPriceWithProduct", nameof(price));
            }

            Price = price;
            Quantity = quantity;
        }
    }
} 