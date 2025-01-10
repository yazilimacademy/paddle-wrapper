using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Adjustments
{
    public class AdjustmentItem
    {
        public string Id { get; }
        public string ItemId { get; }
        public AdjustmentType Type { get; }
        public string Amount { get; }
        public Proration Proration { get; }
        public AdjustmentItemTotals Totals { get; }

        public AdjustmentItem(
            string id,
            string itemId,
            AdjustmentType type,
            string amount,
            Proration proration,
            AdjustmentItemTotals totals)
        {
            Id = id;
            ItemId = itemId;
            Type = type;
            Amount = amount;
            Proration = proration;
            Totals = totals;
        }

        public static AdjustmentItem FromDict(JsonElement data)
        {
            return new AdjustmentItem(
                id: data.GetProperty("id").GetString(),
                itemId: data.GetProperty("item_id").GetString(),
                type: Enum.Parse<AdjustmentType>(data.GetProperty("type").GetString()),
                amount: data.TryGetProperty("amount", out var amount) ? amount.GetString() : null,
                proration: data.TryGetProperty("proration", out var proration) ? Proration.FromDict(proration) : null,
                totals: AdjustmentItemTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 