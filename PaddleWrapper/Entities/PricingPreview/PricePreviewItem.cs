using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.PricingPreview
{
    public class PricePreviewItem
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        private PricePreviewItem(string priceId, int quantity)
        {
            PriceId = priceId;
            Quantity = quantity;
        }

        public static PricePreviewItem From(Dictionary<string, object> data)
        {
            return new PricePreviewItem(
                priceId: (string)data["price_id"],
                quantity: (int)data["quantity"]
            );
        }
    }
} 