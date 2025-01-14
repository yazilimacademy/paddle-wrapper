using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.PricingPreview
{
    public class PricePreviewTotalsFormatted
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("discount")]
        public string Discount { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        private PricePreviewTotalsFormatted(
            string subtotal,
            string discount,
            string tax,
            string total)
        {
            Subtotal = subtotal;
            Discount = discount;
            Tax = tax;
            Total = total;
        }

        public static PricePreviewTotalsFormatted From(Dictionary<string, object> data)
        {
            return new PricePreviewTotalsFormatted(
                subtotal: (string)data["subtotal"],
                discount: (string)data["discount"],
                tax: (string)data["tax"],
                total: (string)data["total"]
            );
        }
    }
}