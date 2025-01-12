using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscriptions;

public class SubscriptionAdjustmentItem
{
    [JsonPropertyName("item_id")]
    public string ItemId { get; set; }

    [JsonPropertyName("type")]
    public AdjustmentType Type { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("proration")]
    public AdjustmentProration Proration { get; set; }

    [JsonPropertyName("totals")]
    public AdjustmentItemTotals Totals { get; set; }

    public static SubscriptionAdjustmentItem FromJson(JsonElement data)
    {
        return new SubscriptionAdjustmentItem
        {
            ItemId = data.GetProperty("item_id").GetString()!,
            Type = JsonSerializer.Deserialize<AdjustmentType>(data.GetProperty("type").GetRawText()),
            Amount = data.TryGetProperty("amount", out JsonElement amount) ? amount.GetString() : null,
            Proration = AdjustmentProration.FromJson(data.GetProperty("proration")),
            Totals = AdjustmentItemTotals.FromJson(data.GetProperty("totals"))
        };
    }
}