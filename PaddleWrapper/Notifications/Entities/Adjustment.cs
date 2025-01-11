using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Adjustment;
using PaddleWrapper.Notifications.Entities.Shared;

namespace PaddleWrapper.Notifications.Entities;

public class Adjustment : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("action")]
    public Action Action { get; }

    [JsonPropertyName("transaction_id")]
    public string TransactionId { get; }

    [JsonPropertyName("subscription_id")]
    public string? SubscriptionId { get; }

    [JsonPropertyName("customer_id")]
    public string CustomerId { get; }

    [JsonPropertyName("reason")]
    public string Reason { get; }

    [JsonPropertyName("credit_applied_to_balance")]
    public bool? CreditAppliedToBalance { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode CurrencyCode { get; }

    [JsonPropertyName("status")]
    public AdjustmentStatus Status { get; }

    [JsonPropertyName("items")]
    public IReadOnlyList<AdjustmentItem> Items { get; }

    [JsonPropertyName("totals")]
    public AdjustmentTotals Totals { get; }

    [JsonPropertyName("payout_totals")]
    public PayoutTotalsAdjustment? PayoutTotals { get; }

    [JsonPropertyName("tax_rates_used")]
    public IReadOnlyList<AdjustmentTaxRatesUsed> TaxRatesUsed { get; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; }

    [JsonPropertyName("type")]
    public AdjustmentType? Type { get; }

    private Adjustment(
        string id,
        Action action,
        string transactionId,
        string? subscriptionId,
        string customerId,
        string reason,
        bool? creditAppliedToBalance,
        CurrencyCode currencyCode,
        AdjustmentStatus status,
        IReadOnlyList<AdjustmentItem> items,
        AdjustmentTotals totals,
        PayoutTotalsAdjustment? payoutTotals,
        IReadOnlyList<AdjustmentTaxRatesUsed> taxRatesUsed,
        DateTime createdAt,
        DateTime? updatedAt,
        AdjustmentType? type)
    {
        Id = id;
        Action = action;
        TransactionId = transactionId;
        SubscriptionId = subscriptionId;
        CustomerId = customerId;
        Reason = reason;
        CreditAppliedToBalance = creditAppliedToBalance;
        CurrencyCode = currencyCode;
        Status = status;
        Items = items;
        Totals = totals;
        PayoutTotals = payoutTotals;
        TaxRatesUsed = taxRatesUsed;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Type = type;
    }

    public static Adjustment FromJson(JsonElement json)
    {
        return new Adjustment(
            json.GetProperty("id").GetString()!,
            JsonSerializer.Deserialize<Action>(json.GetProperty("action").GetRawText()),
            json.GetProperty("transaction_id").GetString()!,
            json.TryGetProperty("subscription_id", out var subscriptionId) ? subscriptionId.GetString() : null,
            json.GetProperty("customer_id").GetString()!,
            json.GetProperty("reason").GetString()!,
            json.TryGetProperty("credit_applied_to_balance", out var creditAppliedToBalance) ? creditAppliedToBalance.GetBoolean() : null,
            JsonSerializer.Deserialize<CurrencyCode>(json.GetProperty("currency_code").GetRawText()),
            JsonSerializer.Deserialize<AdjustmentStatus>(json.GetProperty("status").GetRawText()),
            json.GetProperty("items").EnumerateArray()
                .Select(item => AdjustmentItem.FromJson(item))
                .ToList()
                .AsReadOnly(),
            AdjustmentTotals.FromJson(json.GetProperty("totals")),
            json.TryGetProperty("payout_totals", out var payoutTotals) ? PayoutTotalsAdjustment.FromJson(payoutTotals) : null,
            json.GetProperty("tax_rates_used").EnumerateArray()
                .Select(taxRate => AdjustmentTaxRatesUsed.FromJson(taxRate))
                .ToList()
                .AsReadOnly(),
            DateTime.Parse(json.GetProperty("created_at").GetString()!),
            json.TryGetProperty("updated_at", out var updatedAt) ? DateTime.Parse(updatedAt.GetString()!) : null,
            json.TryGetProperty("type", out var type) ? JsonSerializer.Deserialize<AdjustmentType>(type.GetRawText()) : null
        );
    }
} 