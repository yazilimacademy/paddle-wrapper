using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionAdjustmentItem
    {
        [JsonPropertyName("item_id")]
        public string ItemId { get; }

        [JsonPropertyName("type")]
        public AdjustmentType Type { get; }

        [JsonPropertyName("amount")]
        public string? Amount { get; }

        [JsonPropertyName("proration")]
        public AdjustmentProration Proration { get; }

        [JsonPropertyName("totals")]
        public AdjustmentItemTotals Totals { get; }

        private SubscriptionAdjustmentItem(
            string itemId,
            AdjustmentType type,
            string? amount,
            AdjustmentProration proration,
            AdjustmentItemTotals totals)
        {
            ItemId = itemId;
            Type = type;
            Amount = amount;
            Proration = proration;
            Totals = totals;
        }

        public static SubscriptionAdjustmentItem From(Dictionary<string, object> data)
        {
            return new SubscriptionAdjustmentItem(
                itemId: (string)data["item_id"],
                type: System.Enum.Parse<AdjustmentType>((string)data["type"], true),
                amount: data.ContainsKey("amount") ? (string?)data["amount"] : null,
                proration: AdjustmentProration.From((Dictionary<string, object>)data["proration"]),
                totals: AdjustmentItemTotals.From((Dictionary<string, object>)data["totals"])
            );
        }
    }
} 