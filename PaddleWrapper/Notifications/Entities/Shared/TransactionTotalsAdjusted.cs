using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class TransactionTotalsAdjusted
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; }

    [JsonPropertyName("tax")]
    public string Tax { get; }

    [JsonPropertyName("total")]
    public string Total { get; }

    [JsonPropertyName("grand_total")]
    public string GrandTotal { get; }

    [JsonPropertyName("fee")]
    public string? Fee { get; }

    [JsonPropertyName("earnings")]
    public string? Earnings { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode CurrencyCode { get; }

    private TransactionTotalsAdjusted(string subtotal, string tax, string total, string grandTotal, string? fee, string? earnings, CurrencyCode currencyCode)
    {
        Subtotal = subtotal;
        Tax = tax;
        Total = total;
        GrandTotal = grandTotal;
        Fee = fee;
        Earnings = earnings;
        CurrencyCode = currencyCode;
    }

    public static TransactionTotalsAdjusted FromJson(JsonElement json)
    {
        string subtotal = json.GetProperty("subtotal").GetString()!;
        string tax = json.GetProperty("tax").GetString()!;
        string total = json.GetProperty("total").GetString()!;
        string grandTotal = json.GetProperty("grand_total").GetString()!;

        string? fee = null;
        if (json.TryGetProperty("fee", out JsonElement feeElement))
        {
            fee = feeElement.GetString();
        }

        string? earnings = null;
        if (json.TryGetProperty("earnings", out JsonElement earningsElement))
        {
            earnings = earningsElement.GetString();
        }

        CurrencyCode currencyCode = (CurrencyCode)json.GetProperty("currency_code").GetString()!;

        return new TransactionTotalsAdjusted(subtotal, tax, total, grandTotal, fee, earnings, currencyCode);
    }
}