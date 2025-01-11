using System;
using System.Text.Json.Serialization;
using PaddleWrapper.Resources.Transactions.Operations.Price;

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
            if (price is not TransactionNonCatalogPrice && price is not TransactionNonCatalogPriceWithProduct)
            {
                throw new ArgumentException("Price must be either TransactionNonCatalogPrice or TransactionNonCatalogPriceWithProduct", nameof(price));
            }

            Price = price;
            Quantity = quantity;
        }
    }
} 