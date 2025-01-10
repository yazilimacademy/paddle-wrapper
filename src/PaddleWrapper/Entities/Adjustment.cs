namespace PaddleWrapper.Entities
{
    public class Adjustment : Entity
    {
        public Action Action { get; }
        public string TransactionId { get; }
        public string SubscriptionId { get; }
        public string CustomerId { get; }
        public string Reason { get; }
        public bool? CreditAppliedToBalance { get; }
        public CurrencyCode CurrencyCode { get; }
        public AdjustmentStatus Status { get; }
        public List<AdjustmentItem> Items { get; }
        public AdjustmentTotals Totals { get; }
        public PayoutTotalsAdjustment PayoutTotals { get; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
        public List<AdjustmentTaxRatesUsed> TaxRatesUsed { get; }
        public AdjustmentActionType Type { get; }

        public Adjustment(
            string id,
            Action action,
            string transactionId,
            string subscriptionId,
            string customerId,
            string reason,
            bool? creditAppliedToBalance,
            CurrencyCode currencyCode,
            AdjustmentStatus status,
            List<AdjustmentItem> items,
            AdjustmentTotals totals,
            PayoutTotalsAdjustment payoutTotals,
            DateTime createdAt,
            DateTime? updatedAt,
            List<AdjustmentTaxRatesUsed> taxRatesUsed,
            AdjustmentActionType type)
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
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            TaxRatesUsed = taxRatesUsed;
            Type = type;
        }

        public static Adjustment FromDict(JsonElement data)
        {
            return new Adjustment(
                id: data.GetProperty("id").GetString(),
                action: Enum.Parse<Action>(data.GetProperty("action").GetString()),
                transactionId: data.GetProperty("transaction_id").GetString(),
                subscriptionId: data.GetProperty("subscription_id").GetString(),
                customerId: data.GetProperty("customer_id").GetString(),
                reason: data.GetProperty("reason").GetString(),
                creditAppliedToBalance: data.TryGetProperty("credit_applied_to_balance", out var credit) ? credit.GetBoolean() : null,
                currencyCode: Enum.Parse<CurrencyCode>(data.GetProperty("currency_code").GetString()),
                status: Enum.Parse<AdjustmentStatus>(data.GetProperty("status").GetString()),
                items: data.GetProperty("items").EnumerateArray().Select(AdjustmentItem.FromDict).ToList(),
                totals: AdjustmentTotals.FromDict(data.GetProperty("totals")),
                payoutTotals: data.TryGetProperty("payout_totals", out var payout) ? PayoutTotalsAdjustment.FromDict(payout) : null,
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: data.TryGetProperty("updated_at", out var updated) ? DateTime.Parse(updated.GetString()) : null,
                taxRatesUsed: data.GetProperty("tax_rates_used").EnumerateArray().Select(AdjustmentTaxRatesUsed.FromDict).ToList(),
                type: Enum.Parse<AdjustmentActionType>(data.GetProperty("type").GetString())
            );
        }
    }
} 