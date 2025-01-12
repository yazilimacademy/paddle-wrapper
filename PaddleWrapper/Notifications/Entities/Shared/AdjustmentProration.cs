using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class AdjustmentProration
{
    [JsonPropertyName("rate")]
    public string Rate { get; set; }

    [JsonPropertyName("billing_period")]
    public AdjustmentTimePeriod BillingPeriod { get; set; }

    public static AdjustmentProration FromJson(JsonElement data)
    {
        return new AdjustmentProration
        {
            Rate = data.GetProperty("rate").GetString()!,
            BillingPeriod = AdjustmentTimePeriod.FromJson(data.GetProperty("billing_period"))
        };
    }
}