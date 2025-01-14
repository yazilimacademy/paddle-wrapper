using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class PayoutTotalsAdjustment
{
    [JsonPropertyName("subtotal")]
    public string Subtotal { get; }

    [JsonPropertyName("tax")]
    public string Tax { get; }

    [JsonPropertyName("total")]
    public string Total { get; }

    [JsonPropertyName("fee")]
    public string Fee { get; }

    [JsonPropertyName("chargeback_fee")]
    public ChargebackFee? ChargebackFee { get; }

    [JsonPropertyName("earnings")]
    public string Earnings { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCodePayouts CurrencyCode { get; }

    private PayoutTotalsAdjustment(string subtotal, string tax, string total, string fee, ChargebackFee? chargebackFee, string earnings, CurrencyCodePayouts currencyCode)
    {
        Subtotal = subtotal;
        Tax = tax;
        Total = total;
        Fee = fee;
        ChargebackFee = chargebackFee;
        Earnings = earnings;
        CurrencyCode = currencyCode;
    }

    public static PayoutTotalsAdjustment FromJson(JsonElement element)
    {
        return new PayoutTotalsAdjustment(
            element.GetProperty("subtotal").GetString()!,
            element.GetProperty("tax").GetString()!,
            element.GetProperty("total").GetString()!,
            element.GetProperty("fee").GetString()!,
            element.TryGetProperty("chargeback_fee", out JsonElement chargebackFee) ? Shared.ChargebackFee.FromJson(chargebackFee) : null,
            element.GetProperty("earnings").GetString()!,
            JsonSerializer.Deserialize<CurrencyCodePayouts>(element.GetProperty("currency_code").GetRawText())
        );
    }
}