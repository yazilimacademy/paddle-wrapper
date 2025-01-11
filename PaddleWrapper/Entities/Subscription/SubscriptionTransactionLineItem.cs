using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionTransactionLineItem
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("proration")]
        public SubscriptionProration Proration { get; }

        [JsonPropertyName("tax_rate")]
        public string TaxRate { get; }

        [JsonPropertyName("unit_totals")]
        public UnitTotals UnitTotals { get; }

        [JsonPropertyName("totals")]
        public Totals Totals { get; }

        [JsonPropertyName("product")]
        public Product Product { get; }

        private SubscriptionTransactionLineItem(
            string id,
            string priceId,
            int quantity,
            SubscriptionProration proration,
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

        public static SubscriptionTransactionLineItem From(Dictionary<string, object> data)
        {
            return new SubscriptionTransactionLineItem(
                id: (string)data["id"],
                priceId: (string)data["price_id"],
                quantity: (int)data["quantity"],
                proration: SubscriptionProration.From((Dictionary<string, object>)data["proration"]),
                taxRate: (string)data["tax_rate"],
                unitTotals: UnitTotals.From((Dictionary<string, object>)data["unit_totals"]),
                totals: Totals.From((Dictionary<string, object>)data["totals"]),
                product: Product.From((Dictionary<string, object>)data["product"])
            );
        }
    }
} 