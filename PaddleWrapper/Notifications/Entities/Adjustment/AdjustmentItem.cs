using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Shared;

namespace PaddleWrapper.Notifications.Entities.Adjustment;

public class AdjustmentItem
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("item_id")]
    public string ItemId { get; }

    [JsonPropertyName("type")]
    public AdjustmentType Type { get; }

    [JsonPropertyName("amount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Amount { get; }

    [JsonPropertyName("proration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdjustmentProration? Proration { get; }

    [JsonPropertyName("totals")]
    public AdjustmentItemTotals Totals { get; }

    private AdjustmentItem(string id, string itemId, AdjustmentType type, string? amount, AdjustmentProration? proration, AdjustmentItemTotals totals)
    {
        Id = id;
        ItemId = itemId;
        Type = type;
        Amount = amount;
        Proration = proration;
        Totals = totals;
    }

    public static AdjustmentItem From(JsonElement data)
    {
        return new AdjustmentItem(
            id: data.GetProperty("id").GetString()!,
            itemId: data.GetProperty("item_id").GetString()!,
            type: AdjustmentType.From(data.GetProperty("type")),
            amount: data.TryGetProperty("amount", out JsonElement amountElement) ? amountElement.GetString() : null,
            proration: data.TryGetProperty("proration", out JsonElement prorationElement) && !prorationElement.ValueKind.Equals(JsonValueKind.Null) 
                ? AdjustmentProration.From(prorationElement) 
                : null,
            totals: AdjustmentItemTotals.From(data.GetProperty("totals"))
        );
    }
} 