using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Adjustments.Operations.Create
{
    public class AdjustmentItem
    {
        [JsonPropertyName("item_id")]
        public string ItemId { get; set; }

        [JsonPropertyName("type")]
        public AdjustmentType Type { get; set; }

        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        public AdjustmentItem(string itemId, AdjustmentType type, string? amount = null)
        {
            ItemId = itemId;
            Type = type;
            Amount = amount;
        }
    }
}