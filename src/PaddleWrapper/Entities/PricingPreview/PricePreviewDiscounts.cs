using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.PricingPreview
{
    public class PricePreviewDiscounts
    {
        [JsonPropertyName("discount")]
        public Discount Discount { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        [JsonPropertyName("formatted_total")]
        public string FormattedTotal { get; }

        private PricePreviewDiscounts(
            Discount discount,
            string total,
            string formattedTotal)
        {
            Discount = discount;
            Total = total;
            FormattedTotal = formattedTotal;
        }

        public static PricePreviewDiscounts From(Dictionary<string, object> data)
        {
            return new PricePreviewDiscounts(
                discount: Discount.From((Dictionary<string, object>)data["discount"]),
                total: (string)data["total"],
                formattedTotal: (string)data["formatted_total"]
            );
        }
    }
}