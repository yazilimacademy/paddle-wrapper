using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionPreviewItem
    {
        public string PriceId { get; }
        public string Quantity { get; }
        public Proration Proration { get; }
        public TransactionPreviewItemTotals Totals { get; }

        public TransactionPreviewItem(
            string priceId,
            string quantity,
            Proration proration,
            TransactionPreviewItemTotals totals)
        {
            PriceId = priceId;
            Quantity = quantity;
            Proration = proration;
            Totals = totals;
        }

        public static TransactionPreviewItem FromDict(JsonElement data)
        {
            return new TransactionPreviewItem(
                priceId: data.GetProperty("price_id").GetString(),
                quantity: data.GetProperty("quantity").GetString(),
                proration: data.TryGetProperty("proration", out var proration) ? 
                    Proration.FromDict(proration) : null,
                totals: TransactionPreviewItemTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 