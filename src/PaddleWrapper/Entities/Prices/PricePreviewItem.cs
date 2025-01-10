using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Prices
{
    public class PricePreviewItem
    {
        public string PriceId { get; }
        public string Quantity { get; }
        public Proration Proration { get; }
        public PricePreviewItemTotals Totals { get; }

        public PricePreviewItem(
            string priceId,
            string quantity,
            Proration proration,
            PricePreviewItemTotals totals)
        {
            PriceId = priceId;
            Quantity = quantity;
            Proration = proration;
            Totals = totals;
        }

        public static PricePreviewItem FromDict(JsonElement data)
        {
            return new PricePreviewItem(
                priceId: data.GetProperty("price_id").GetString(),
                quantity: data.GetProperty("quantity").GetString(),
                proration: data.TryGetProperty("proration", out var proration) ? 
                    Proration.FromDict(proration) : null,
                totals: PricePreviewItemTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 