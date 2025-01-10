using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionItem
    {
        public string PriceId { get; }
        public string Quantity { get; }
        public Proration Proration { get; }
        public TransactionItemTotals Totals { get; }

        public TransactionItem(
            string priceId,
            string quantity,
            Proration proration,
            TransactionItemTotals totals)
        {
            PriceId = priceId;
            Quantity = quantity;
            Proration = proration;
            Totals = totals;
        }

        public static TransactionItem FromDict(JsonElement data)
        {
            return new TransactionItem(
                priceId: data.GetProperty("price_id").GetString(),
                quantity: data.GetProperty("quantity").GetString(),
                proration: data.TryGetProperty("proration", out var proration) ? 
                    Proration.FromDict(proration) : null,
                totals: TransactionItemTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 