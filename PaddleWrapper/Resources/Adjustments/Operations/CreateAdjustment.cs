using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Adjustments.Operations.Create;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Adjustments.Operations
{
    public class CreateAdjustment
    {
        [JsonPropertyName("action")]
        public Action Action { get; }

        [JsonPropertyName("items")]
        public List<AdjustmentItem>? Items { get; }

        [JsonPropertyName("reason")]
        public string Reason { get; }

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; }

        [JsonPropertyName("type")]
        public AdjustmentType? Type { get; }

        private CreateAdjustment(Action action, List<AdjustmentItem>? items, string reason, string transactionId, AdjustmentType? type)
        {
            if (type == AdjustmentType.Full && items != null && items.Any())
            {
                throw new ArgumentException("Items are not allowed when the adjustment type is full");
            }

            if (type != AdjustmentType.Full && (items == null || !items.Any()))
            {
                throw new ArgumentException("Items cannot be empty for partial adjustments");
            }

            Action = action;
            Items = items;
            Reason = reason;
            TransactionId = transactionId;
            Type = type;
        }

        public static CreateAdjustment Full(Action action, string reason, string transactionId)
        {
            return new CreateAdjustment(action, null, reason, transactionId, AdjustmentType.Full);
        }

        public static CreateAdjustment Partial(Action action, List<AdjustmentItem> items, string reason, string transactionId)
        {
            return new CreateAdjustment(action, items, reason, transactionId, AdjustmentType.Partial);
        }
    }
}