using System.Text.Json.Serialization;
using PaddleWrapper.Resources.Transactions.Operations.Price;

namespace PaddleWrapper.Resources.Transactions.Operations.Preview
{
    public class TransactionItemPreviewWithNonCatalogPrice
    {
        [JsonPropertyName("price")]
        public object Price { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("include_in_totals")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeInTotals { get; }

        public TransactionItemPreviewWithNonCatalogPrice(object price, int quantity, bool? includeInTotals = null)
        {
            if (price is not TransactionNonCatalogPrice && price is not TransactionNonCatalogPriceWithProduct)
            {
                throw new System.ArgumentException("Price must be either TransactionNonCatalogPrice or TransactionNonCatalogPriceWithProduct", nameof(price));
            }

            Price = price;
            Quantity = quantity;
            IncludeInTotals = includeInTotals;
        }
    }
} 