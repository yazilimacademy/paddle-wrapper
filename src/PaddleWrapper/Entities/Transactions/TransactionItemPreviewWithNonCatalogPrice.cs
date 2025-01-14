using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionItemPreviewWithNonCatalogPrice
    {
        [JsonPropertyName("price")]
        public object Price { get; }  // Can be either TransactionNonCatalogPrice or TransactionNonCatalogPriceWithProduct

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("include_in_totals")]
        public bool? IncludeInTotals { get; }

        private TransactionItemPreviewWithNonCatalogPrice(
            object price,
            int quantity,
            bool? includeInTotals)
        {
            Price = price;
            Quantity = quantity;
            IncludeInTotals = includeInTotals;
        }

        public static TransactionItemPreviewWithNonCatalogPrice From(Dictionary<string, object> data)
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

            return new TransactionItemPreviewWithNonCatalogPrice(
                price: price,
                quantity: (int)data["quantity"],
                includeInTotals: data.ContainsKey("include_in_totals") ? (bool?)data["include_in_totals"] : null
            );
        }
    }
}