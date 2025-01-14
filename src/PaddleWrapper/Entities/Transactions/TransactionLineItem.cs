using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionLineItem
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("proration")]
        public TransactionProration? Proration { get; }

        [JsonPropertyName("tax_rate")]
        public string TaxRate { get; }

        [JsonPropertyName("unit_totals")]
        public UnitTotals UnitTotals { get; }

        [JsonPropertyName("totals")]
        public Totals Totals { get; }

        [JsonPropertyName("product")]
        public Product Product { get; }

        private TransactionLineItem(
            string id,
            string priceId,
            int quantity,
            TransactionProration? proration,
            string taxRate,
            UnitTotals unitTotals,
            Totals totals,
            Product product)
        {
            Id = id;
            PriceId = priceId;
            Quantity = quantity;
            Proration = proration;
            TaxRate = taxRate;
            UnitTotals = unitTotals;
            Totals = totals;
            Product = product;
        }

        public static TransactionLineItem From(Dictionary<string, object> data)
        {
            return new TransactionLineItem(
                id: (string)data["id"],
                priceId: (string)data["price_id"],
                quantity: (int)data["quantity"],
                proration: data.ContainsKey("proration") ? TransactionProration.From((Dictionary<string, object>)data["proration"]) : null,
                taxRate: (string)data["tax_rate"],
                unitTotals: UnitTotals.From((Dictionary<string, object>)data["unit_totals"]),
                totals: Totals.From((Dictionary<string, object>)data["totals"]),
                product: Product.From((Dictionary<string, object>)data["product"])
            );
        }
    }
}