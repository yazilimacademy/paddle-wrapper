using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class Totals
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; }

    [JsonPropertyName("discount")]
    public string Discount { get; }

    [JsonPropertyName("tax")]
    public string Tax { get; }

    [JsonPropertyName("total")]
    public string Total { get; }

    private Totals(string subtotal, string discount, string tax, string total)
    {
        Subtotal = subtotal;
        Discount = discount;
        Tax = tax;
        Total = total;
    }

    public static Totals FromJson(JsonElement element)
    {
        return new Totals(
            element.GetProperty("subtotal").GetString()!,
            element.GetProperty("discount").GetString()!,
            element.GetProperty("tax").GetString()!,
            element.GetProperty("total").GetString()!
        );
    }
}