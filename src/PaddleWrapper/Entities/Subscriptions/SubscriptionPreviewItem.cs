using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionPreviewItem
    {
        public string PriceId { get; }
        public string Quantity { get; }
        public Proration Proration { get; }
        public SubscriptionPreviewItemTotals Totals { get; }

        public SubscriptionPreviewItem(
            string priceId,
            string quantity,
            Proration proration,
            SubscriptionPreviewItemTotals totals)
        {
            PriceId = priceId;
            Quantity = quantity;
            Proration = proration;
            Totals = totals;
        }

        public static SubscriptionPreviewItem FromDict(JsonElement data)
        {
            return new SubscriptionPreviewItem(
                priceId: data.GetProperty("price_id").GetString(),
                quantity: data.GetProperty("quantity").GetString(),
                proration: data.TryGetProperty("proration", out var proration) ? 
                    Proration.FromDict(proration) : null,
                totals: SubscriptionPreviewItemTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 