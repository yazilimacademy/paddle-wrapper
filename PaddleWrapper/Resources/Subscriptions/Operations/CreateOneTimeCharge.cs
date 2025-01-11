using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Subscription;

namespace PaddleWrapper.Resources.Subscriptions.Operations
{
    public class CreateOneTimeCharge
    {
        [JsonPropertyName("effective_from")]
        public string EffectiveFrom { get; }

        [JsonPropertyName("items")]
        public IEnumerable<SubscriptionItems> Items { get; }

        [JsonPropertyName("on_payment_failure")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OnPaymentFailure { get; }

        [JsonPropertyName("receipt_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReceiptData { get; }

        public CreateOneTimeCharge(
            SubscriptionEffectiveFrom effectiveFrom,
            IEnumerable<SubscriptionItems> items,
            SubscriptionOnPaymentFailure? onPaymentFailure = null,
            string? receiptData = null)
        {
            EffectiveFrom = effectiveFrom.ToString().ToLower();
            Items = items;
            OnPaymentFailure = onPaymentFailure?.ToString()?.ToLower();
            ReceiptData = receiptData;
        }
    }
} 