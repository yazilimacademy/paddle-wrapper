using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Transactions;

public class TransactionAdjustmentsTotals
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; }

    [JsonPropertyName("tax")]
    public string Tax { get; }

    [JsonPropertyName("total")]
    public string Total { get; }

    [JsonPropertyName("fee")]
    public string Fee { get; }

    [JsonPropertyName("earnings")]
    public string Earnings { get; }

    [JsonPropertyName("breakdown")]
    public TransactionBreakdown Breakdown { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode CurrencyCode { get; }

    private TransactionAdjustmentsTotals(string subtotal, string tax, string total, string fee, string earnings, TransactionBreakdown breakdown, CurrencyCode currencyCode)
    {
        Subtotal = subtotal;
        Tax = tax;
        Total = total;
        Fee = fee;
        Earnings = earnings;
        Breakdown = breakdown;
        CurrencyCode = currencyCode;
    }

    public static TransactionAdjustmentsTotals From(JsonElement data)
    {
        return new TransactionAdjustmentsTotals(
            data.GetProperty("subtotal").GetString()!,
            data.GetProperty("tax").GetString()!,
            data.GetProperty("total").GetString()!,
            data.GetProperty("fee").GetString()!,
            data.GetProperty("earnings").GetString()!,
            TransactionBreakdown.From(data.GetProperty("breakdown")),
            CurrencyCode.From(data.GetProperty("currency_code").GetString()!)
        );
    }
}