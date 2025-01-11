using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Transaction;

namespace PaddleWrapper.Entities.Shared
{
    public class TransactionLineItemPreview
    {
        [JsonPropertyName("price_id")]
        public string? PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("tax_rate")]
        public string TaxRate { get; }

        [JsonPropertyName("unit_totals")]
        public UnitTotals UnitTotals { get; }

        [JsonPropertyName("totals")]
        public Totals Totals { get; }

        [JsonPropertyName("product")]
        public TransactionPreviewProduct Product { get; }

        [JsonPropertyName("proration")]
        public TransactionProration? Proration { get; }

        [JsonConstructor]
        public TransactionLineItemPreview(
            string? priceId,
            int quantity,
            string taxRate,
            UnitTotals unitTotals,
            Totals totals,
            TransactionPreviewProduct product,
            TransactionProration? proration = null)
        {
            PriceId = priceId;
            Quantity = quantity;
            TaxRate = taxRate;
            UnitTotals = unitTotals;
            Totals = totals;
            Product = product;
            Proration = proration;
        }

        public static TransactionLineItemPreview From(Dictionary<string, object> data)
        {
            return new TransactionLineItemPreview(
                priceId: data.ContainsKey("price_id") ? data["price_id"]?.ToString() : null,
                quantity: Convert.ToInt32(data["quantity"]),
                taxRate: data["tax_rate"].ToString(),
                unitTotals: UnitTotals.From((Dictionary<string, object>)data["unit_totals"]),
                totals: Totals.From((Dictionary<string, object>)data["totals"]),
                product: TransactionPreviewProduct.From((Dictionary<string, object>)data["product"]),
                proration: data.ContainsKey("proration") && data["proration"] != null
                    ? TransactionProration.From((Dictionary<string, object>)data["proration"])
                    : null
            );
        }
    }
} 