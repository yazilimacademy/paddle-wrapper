using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class UnitTotals
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; }

    [JsonPropertyName("discount")]
    public string Discount { get; }

    [JsonPropertyName("tax")]
    public string Tax { get; }

    [JsonPropertyName("total")]
    public string Total { get; }

    private UnitTotals(string subtotal, string discount, string tax, string total)
    {
        Subtotal = subtotal;
        Discount = discount;
        Tax = tax;
        Total = total;
    }

    public static UnitTotals FromJson(JsonElement json)
    {
        var subtotal = json.GetProperty("subtotal").GetString()!;
        var discount = json.GetProperty("discount").GetString()!;
        var tax = json.GetProperty("tax").GetString()!;
        var total = json.GetProperty("total").GetString()!;

        return new UnitTotals(subtotal, discount, tax, total);
    }
} 