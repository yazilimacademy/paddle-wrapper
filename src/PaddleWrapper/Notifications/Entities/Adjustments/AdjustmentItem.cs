using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharedAdjustmentType = PaddleWrapper.Notifications.Entities.Shared.AdjustmentType;

namespace PaddleWrapper.Notifications.Entities.Adjustments;

public class AdjustmentItem
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("item_id")]
    public string ItemId { get; }

    [JsonPropertyName("type")]
    public SharedAdjustmentType Type { get; }

    [JsonPropertyName("amount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Amount { get; }

    [JsonPropertyName("proration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdjustmentProration? Proration { get; }

    [JsonPropertyName("totals")]
    public AdjustmentItemTotals Totals { get; }

    private AdjustmentItem(string id, string itemId, SharedAdjustmentType type, string? amount, AdjustmentProration? proration, AdjustmentItemTotals totals)
    {
        Id = id;
        ItemId = itemId;
        Type = type;
        Amount = amount;
        Proration = proration;
        Totals = totals;
    }

    public static AdjustmentItem FromJson(JsonElement data)
    {
        return new AdjustmentItem(
            id: data.GetProperty("id").GetString()!,
            itemId: data.GetProperty("item_id").GetString()!,
            type: PaddleEnum.FromJson<SharedAdjustmentType>(data.GetProperty("type")),
            amount: data.TryGetProperty("amount", out JsonElement amountElement) ? amountElement.GetString() : null,
            proration: data.TryGetProperty("proration", out JsonElement prorationElement) && !prorationElement.ValueKind.Equals(JsonValueKind.Null)
                ? AdjustmentProration.FromJson(prorationElement)
                : null,
            totals: AdjustmentItemTotals.FromJson(data.GetProperty("totals"))
        );
    }
}