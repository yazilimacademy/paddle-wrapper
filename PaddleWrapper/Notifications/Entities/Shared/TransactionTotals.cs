using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class TransactionTotals
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; }

    [JsonPropertyName("discount")]
    public string Discount { get; }

    [JsonPropertyName("tax")]
    public string Tax { get; }

    [JsonPropertyName("total")]
    public string Total { get; }

    [JsonPropertyName("credit")]
    public string Credit { get; }

    [JsonPropertyName("balance")]
    public string Balance { get; }

    [JsonPropertyName("grand_total")]
    public string? GrandTotal { get; }

    [JsonPropertyName("fee")]
    public string? Fee { get; }

    [JsonPropertyName("earnings")]
    public string? Earnings { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode CurrencyCode { get; }

    [JsonPropertyName("credit_to_balance")]
    public string? CreditToBalance { get; }

    private TransactionTotals(
        string subtotal,
        string discount,
        string tax,
        string total,
        string credit,
        string balance,
        string? grandTotal,
        string? fee,
        string? earnings,
        CurrencyCode currencyCode,
        string? creditToBalance)
    {
        Subtotal = subtotal;
        Discount = discount;
        Tax = tax;
        Total = total;
        Credit = credit;
        Balance = balance;
        GrandTotal = grandTotal;
        Fee = fee;
        Earnings = earnings;
        CurrencyCode = currencyCode;
        CreditToBalance = creditToBalance;
    }

    public static TransactionTotals FromJson(JsonElement element)
    {
        return new TransactionTotals(
            element.GetProperty("subtotal").GetString()!,
            element.GetProperty("discount").GetString()!,
            element.GetProperty("tax").GetString()!,
            element.GetProperty("total").GetString()!,
            element.GetProperty("credit").GetString()!,
            element.GetProperty("balance").GetString()!,
            element.TryGetProperty("grand_total", out JsonElement grandTotal) ? grandTotal.GetString() : null,
            element.TryGetProperty("fee", out JsonElement fee) ? fee.GetString() : null,
            element.TryGetProperty("earnings", out JsonElement earnings) ? earnings.GetString() : null,
            JsonSerializer.Deserialize<CurrencyCode>(element.GetProperty("currency_code").GetRawText()),
            element.TryGetProperty("credit_to_balance", out JsonElement creditToBalance) ? creditToBalance.GetString() : null
        );
    }
}