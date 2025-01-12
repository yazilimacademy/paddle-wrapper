using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Entities.Subscriptions;
using System.Text.Json.Serialization;
using SubscriptionDiscount = PaddleWrapper.Resources.Subscriptions.Operations.Update.SubscriptionDiscount;

namespace PaddleWrapper.Resources.Subscriptions.Operations
{
    public class UpdateSubscription
    {
        [JsonPropertyName("customer_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CustomerId { get; }

        [JsonPropertyName("address_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AddressId { get; }

        [JsonPropertyName("business_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BusinessId { get; }

        [JsonPropertyName("currency_code")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CurrencyCode { get; }

        [JsonPropertyName("next_billed_at")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NextBilledAt { get; }

        [JsonPropertyName("discount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SubscriptionDiscount? Discount { get; }

        [JsonPropertyName("collection_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CollectionMode { get; }

        [JsonPropertyName("billing_details")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BillingDetails? BillingDetails { get; }

        [JsonPropertyName("scheduled_change")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? ScheduledChange { get; }

        [JsonPropertyName("items")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<SubscriptionItems>? Items { get; }

        [JsonPropertyName("custom_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomData? CustomData { get; }

        [JsonPropertyName("proration_billing_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ProrationBillingMode { get; }

        [JsonPropertyName("on_payment_failure")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OnPaymentFailure { get; }

        public UpdateSubscription(
            string? customerId = null,
            string? addressId = null,
            string? businessId = null,
            CurrencyCode? currencyCode = null,
            DateTime? nextBilledAt = null,
            SubscriptionDiscount? discount = null,
            CollectionMode? collectionMode = null,
            BillingDetails? billingDetails = null,
            object? scheduledChange = null,
            IEnumerable<SubscriptionItems>? items = null,
            CustomData? customData = null,
            SubscriptionProrationBillingMode? prorationBillingMode = null,
            SubscriptionOnPaymentFailure? onPaymentFailure = null)
        {
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode?.ToString();
            NextBilledAt = nextBilledAt?.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            Discount = discount;
            CollectionMode = collectionMode?.ToString()?.ToLower();
            BillingDetails = billingDetails;
            ScheduledChange = scheduledChange;
            Items = items;
            CustomData = customData;
            ProrationBillingMode = prorationBillingMode?.ToString()?.ToLower();
            OnPaymentFailure = onPaymentFailure?.ToString()?.ToLower();
        }
    }
}