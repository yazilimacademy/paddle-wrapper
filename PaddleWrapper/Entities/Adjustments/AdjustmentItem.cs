using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Adjustments
{
    public class AdjustmentItem
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("item_id")]
        public string ItemId { get; }

        [JsonPropertyName("type")]
        public AdjustmentType Type { get; }

        [JsonPropertyName("amount")]
        public string? Amount { get; }

        [JsonPropertyName("proration")]
        public AdjustmentProration? Proration { get; }

        [JsonPropertyName("totals")]
        public AdjustmentItemTotals Totals { get; }

        [JsonConstructor]
        public AdjustmentItem(
            string id,
            string itemId,
            AdjustmentType type,
            string? amount,
            AdjustmentProration? proration,
            AdjustmentItemTotals totals)
        {
            Id = id;
            ItemId = itemId;
            Type = type;
            Amount = amount;
            Proration = proration;
            Totals = totals;
        }

        public static AdjustmentItem From(Dictionary<string, object> data)
        {
            return new AdjustmentItem(
                id: data["id"].ToString(),
                itemId: data["item_id"].ToString(),
                type: Enum.Parse<AdjustmentType>(data["type"].ToString(), true),
                amount: data.ContainsKey("amount") ? data["amount"]?.ToString() : null,
                proration: data.ContainsKey("proration") && data["proration"] != null
                    ? AdjustmentProration.From((Dictionary<string, object>)data["proration"])
                    : null,
                totals: AdjustmentItemTotals.From((Dictionary<string, object>)data["totals"])
            );
        }
    }
}