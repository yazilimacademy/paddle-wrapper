using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.PricingPreview
{
    public class PricePreviewUnitTotalsFormatted
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("discount")]
        public string Discount { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        private PricePreviewUnitTotalsFormatted(
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

        public static PricePreviewUnitTotalsFormatted From(Dictionary<string, object> data)
        {
            return new PricePreviewUnitTotalsFormatted(
                subtotal: (string)data["subtotal"],
                discount: (string)data["discount"],
                tax: (string)data["tax"],
                total: (string)data["total"]
            );
        }
    }
} 