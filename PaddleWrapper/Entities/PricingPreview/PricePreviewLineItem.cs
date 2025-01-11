using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.PricingPreview
{
    public class PricePreviewLineItem
    {
        [JsonPropertyName("price")]
        public Price.Price Price { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("tax_rate")]
        public string TaxRate { get; }

        [JsonPropertyName("unit_totals")]
        public UnitTotals UnitTotals { get; }

        [JsonPropertyName("formatted_unit_totals")]
        public PricePreviewUnitTotalsFormatted FormattedUnitTotals { get; }

        [JsonPropertyName("totals")]
        public Totals Totals { get; }

        [JsonPropertyName("formatted_totals")]
        public PricePreviewTotalsFormatted FormattedTotals { get; }

        [JsonPropertyName("product")]
        public Product Product { get; }

        [JsonPropertyName("discounts")]
        public IReadOnlyList<PricePreviewDiscounts> Discounts { get; }

        private PricePreviewLineItem(
            Price price,
            int quantity,
            string taxRate,
            UnitTotals unitTotals,
            PricePreviewUnitTotalsFormatted formattedUnitTotals,
            Totals totals,
            PricePreviewTotalsFormatted formattedTotals,
            Product product,
            IReadOnlyList<PricePreviewDiscounts> discounts)
        {
            Price = price;
            Quantity = quantity;
            TaxRate = taxRate;
            UnitTotals = unitTotals;
            FormattedUnitTotals = formattedUnitTotals;
            Totals = totals;
            FormattedTotals = formattedTotals;
            Product = product;
            Discounts = discounts;
        }

        public static PricePreviewLineItem From(Dictionary<string, object> data)
        {
            List<PricePreviewDiscounts> discounts = new();
            object[] discountsData = (object[])data["discounts"];
            foreach (object item in discountsData)
            {
                discounts.Add(PricePreviewDiscounts.From((Dictionary<string, object>)item));
            }

            return new PricePreviewLineItem(
                price: Price.From((Dictionary<string, object>)data["price"]),
                quantity: (int)data["quantity"],
                taxRate: (string)data["tax_rate"],
                unitTotals: UnitTotals.From((Dictionary<string, object>)data["unit_totals"]),
                formattedUnitTotals: PricePreviewUnitTotalsFormatted.From((Dictionary<string, object>)data["formatted_unit_totals"]),
                totals: Totals.From((Dictionary<string, object>)data["totals"]),
                formattedTotals: PricePreviewTotalsFormatted.From((Dictionary<string, object>)data["formatted_totals"]),
                product: Product.From((Dictionary<string, object>)data["product"]),
                discounts: discounts
            );
        }
    }
}