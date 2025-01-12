using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Payouts;
using PaddleWrapper.Notifications.Entities.Shared;

namespace PaddleWrapper.Notifications.Entities;

public class Payout : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("status")]
    public PayoutStatus Status { get; }

    [JsonPropertyName("amount")]
    public string Amount { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCodePayouts CurrencyCode { get; }

    private Payout(
        string id,
        PayoutStatus status,
        string amount,
        CurrencyCodePayouts currencyCode)
    {
        Id = id;
        Status = status;
        Amount = amount;
        CurrencyCode = currencyCode;
    }

    public static IEntity FromJson(JsonElement json)
    {
        return new Payout(
            id: json.GetProperty("id").GetString()!,
            status: JsonSerializer.Deserialize<PayoutStatus>(json.GetProperty("status").GetRawText())!,
            amount: json.GetProperty("amount").GetString()!,
            currencyCode: JsonSerializer.Deserialize<CurrencyCodePayouts>(json.GetProperty("currency_code").GetRawText())!
        );
    }
} 