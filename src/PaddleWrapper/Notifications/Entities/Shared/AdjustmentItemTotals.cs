using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class AdjustmentItemTotals
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; set; }

    [JsonPropertyName("tax")]
    public string Tax { get; set; }

    [JsonPropertyName("total")]
    public string Total { get; set; }

    public static AdjustmentItemTotals FromJson(JsonElement data)
    {
        return new AdjustmentItemTotals
        {
            Subtotal = data.GetProperty("subtotal").GetString()!,
            Tax = data.GetProperty("tax").GetString()!,
            Total = data.GetProperty("total").GetString()!
        };
    }
}