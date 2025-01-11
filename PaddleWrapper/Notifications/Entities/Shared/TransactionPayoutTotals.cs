using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class TransactionPayoutTotals
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; }

    [JsonPropertyName("discount")]
    public string? Discount { get; }

    [JsonPropertyName("tax")]
    public string Tax { get; }

    [JsonPropertyName("total")]
    public string Total { get; }

    [JsonPropertyName("credit")]
    public string? Credit { get; }

    [JsonPropertyName("balance")]
    public string? Balance { get; }

    [JsonPropertyName("grand_total")]
    public string? GrandTotal { get; }

    [JsonPropertyName("fee")]
    public string Fee { get; }

    [JsonPropertyName("earnings")]
    public string Earnings { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCodePayouts CurrencyCode { get; }

    [JsonPropertyName("credit_to_balance")]
    public string? CreditToBalance { get; }

    private TransactionPayoutTotals(
        string subtotal,
        string? discount,
        string tax,
        string total,
        string? credit,
        string? balance,
        string? grandTotal,
        string fee,
        string earnings,
        CurrencyCodePayouts currencyCode,
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

    public static TransactionPayoutTotals FromJson(JsonElement element)
    {
        return new TransactionPayoutTotals(
            element.GetProperty("subtotal").GetString()!,
            element.TryGetProperty("discount", out var discount) ? discount.GetString() : null,
            element.GetProperty("tax").GetString()!,
            element.GetProperty("total").GetString()!,
            element.TryGetProperty("credit", out var credit) ? credit.GetString() : null,
            element.TryGetProperty("balance", out var balance) ? balance.GetString() : null,
            element.TryGetProperty("grand_total", out var grandTotal) ? grandTotal.GetString() : null,
            element.GetProperty("fee").GetString()!,
            element.GetProperty("earnings").GetString()!,
            JsonSerializer.Deserialize<CurrencyCodePayouts>(element.GetProperty("currency_code").GetRawText()),
            element.TryGetProperty("credit_to_balance", out var creditToBalance) ? creditToBalance.GetString() : null
        );
    }
} 