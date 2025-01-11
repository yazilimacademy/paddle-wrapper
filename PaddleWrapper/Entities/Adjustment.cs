using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;
using Action = PaddleWrapper.Entities.Shared.Action;

namespace PaddleWrapper.Entities
{
    public class Adjustment
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
        public AdjustmentType Type { get; }

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
            AdjustmentType type)
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

        public static Adjustment From(Dictionary<string, object> data)
        {
            List<AdjustmentItem> items = new();
            if (data.ContainsKey("items"))
            {
                object[] itemsData = (object[])data["items"];
                foreach (object item in itemsData)
                {
                    items.Add(AdjustmentItem.From((Dictionary<string, object>)item));
                }
            }

            List<AdjustmentTaxRatesUsed> taxRatesUsed = new();
            if (data.ContainsKey("tax_rates_used"))
            {
                object[] taxRatesData = (object[])data["tax_rates_used"];
                foreach (object taxRate in taxRatesData)
                {
                    taxRatesUsed.Add(AdjustmentTaxRatesUsed.From((Dictionary<string, object>)taxRate));
                }
            }

            return new Adjustment(
                id: (string)data["id"],
                action: System.Enum.Parse<Action>((string)data["action"], true),
                transactionId: (string)data["transaction_id"],
                subscriptionId: data.ContainsKey("subscription_id") ? (string?)data["subscription_id"] : null,
                customerId: (string)data["customer_id"],
                reason: (string)data["reason"],
                creditAppliedToBalance: data.ContainsKey("credit_applied_to_balance") ?
                    (bool?)data["credit_applied_to_balance"] : null,
                currencyCode: System.Enum.Parse<CurrencyCode>((string)data["currency_code"], true),
                status: System.Enum.Parse<AdjustmentStatus>((string)data["status"], true),
                items: items,
                totals: AdjustmentTotals.From((Dictionary<string, object>)data["totals"]),
                payoutTotals: data.ContainsKey("payout_totals") ?
                    PayoutTotalsAdjustment.From((Dictionary<string, object>)data["payout_totals"]) : null,
                taxRatesUsed: taxRatesUsed,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: data.ContainsKey("updated_at") ? DateTime.Parse((string)data["updated_at"]) : null,
                type: System.Enum.Parse<AdjustmentType>((string)data["type"], true)
            );
        }
    }
}