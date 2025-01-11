using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Entities.Subscription;

namespace PaddleWrapper.Entities
{
    public class SubscriptionPreview
    {
        [JsonPropertyName("status")]
        public SubscriptionStatus Status { get; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; }

        [JsonPropertyName("address_id")]
        public string AddressId { get; }

        [JsonPropertyName("business_id")]
        public string? BusinessId { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        [JsonPropertyName("started_at")]
        public DateTime? StartedAt { get; }

        [JsonPropertyName("first_billed_at")]
        public DateTime? FirstBilledAt { get; }

        [JsonPropertyName("next_billed_at")]
        public DateTime? NextBilledAt { get; }

        [JsonPropertyName("paused_at")]
        public DateTime? PausedAt { get; }

        [JsonPropertyName("canceled_at")]
        public DateTime? CanceledAt { get; }

        [JsonPropertyName("discount")]
        public SubscriptionDiscount? Discount { get; }

        [JsonPropertyName("collection_mode")]
        public CollectionMode CollectionMode { get; }

        [JsonPropertyName("billing_details")]
        public BillingDetails? BillingDetails { get; }

        [JsonPropertyName("current_billing_period")]
        public SubscriptionTimePeriod? CurrentBillingPeriod { get; }

        [JsonPropertyName("billing_cycle")]
        public TimePeriod BillingCycle { get; }

        [JsonPropertyName("scheduled_change")]
        public SubscriptionScheduledChange? ScheduledChange { get; }

        [JsonPropertyName("management_urls")]
        public SubscriptionManagementUrls ManagementUrls { get; }

        [JsonPropertyName("items")]
        public IReadOnlyList<SubscriptionItem> Items { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        [JsonPropertyName("immediate_transaction")]
        public SubscriptionNextTransaction? ImmediateTransaction { get; }

        [JsonPropertyName("next_transaction")]
        public SubscriptionNextTransaction? NextTransaction { get; }

        [JsonPropertyName("recurring_transaction_details")]
        public TransactionDetailsPreview? RecurringTransactionDetails { get; }

        [JsonPropertyName("update_summary")]
        public SubscriptionPreviewSubscriptionUpdateSummary? UpdateSummary { get; }

        private SubscriptionPreview(
            SubscriptionStatus status,
            string customerId,
            string addressId,
            string? businessId,
            CurrencyCode currencyCode,
            DateTime createdAt,
            DateTime updatedAt,
            DateTime? startedAt,
            DateTime? firstBilledAt,
            DateTime? nextBilledAt,
            DateTime? pausedAt,
            DateTime? canceledAt,
            SubscriptionDiscount? discount,
            CollectionMode collectionMode,
            BillingDetails? billingDetails,
            SubscriptionTimePeriod? currentBillingPeriod,
            TimePeriod billingCycle,
            SubscriptionScheduledChange? scheduledChange,
            SubscriptionManagementUrls managementUrls,
            IReadOnlyList<SubscriptionItem> items,
            CustomData? customData,
            SubscriptionNextTransaction? immediateTransaction,
            SubscriptionNextTransaction? nextTransaction,
            TransactionDetailsPreview? recurringTransactionDetails,
            SubscriptionPreviewSubscriptionUpdateSummary? updateSummary)
        {
            Status = status;
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            StartedAt = startedAt;
            FirstBilledAt = firstBilledAt;
            NextBilledAt = nextBilledAt;
            PausedAt = pausedAt;
            CanceledAt = canceledAt;
            Discount = discount;
            CollectionMode = collectionMode;
            BillingDetails = billingDetails;
            CurrentBillingPeriod = currentBillingPeriod;
            BillingCycle = billingCycle;
            ScheduledChange = scheduledChange;
            ManagementUrls = managementUrls;
            Items = items;
            CustomData = customData;
            ImmediateTransaction = immediateTransaction;
            NextTransaction = nextTransaction;
            RecurringTransactionDetails = recurringTransactionDetails;
            UpdateSummary = updateSummary;
        }

        public static SubscriptionPreview From(Dictionary<string, object> data)
        {
            var items = new List<SubscriptionItem>();
            if (data.ContainsKey("items"))
            {
                var itemsData = (object[])data["items"];
                foreach (var item in itemsData)
                {
                    items.Add(SubscriptionItem.From((Dictionary<string, object>)item));
                }
            }

            return new SubscriptionPreview(
                status: System.Enum.Parse<SubscriptionStatus>((string)data["status"], true),
                customerId: (string)data["customer_id"],
                addressId: (string)data["address_id"],
                businessId: data.ContainsKey("business_id") ? (string?)data["business_id"] : null,
                currencyCode: System.Enum.Parse<CurrencyCode>((string)data["currency_code"], true),
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"]),
                startedAt: data.ContainsKey("started_at") ? DateTime.Parse((string)data["started_at"]) : null,
                firstBilledAt: data.ContainsKey("first_billed_at") ? DateTime.Parse((string)data["first_billed_at"]) : null,
                nextBilledAt: data.ContainsKey("next_billed_at") ? DateTime.Parse((string)data["next_billed_at"]) : null,
                pausedAt: data.ContainsKey("paused_at") ? DateTime.Parse((string)data["paused_at"]) : null,
                canceledAt: data.ContainsKey("canceled_at") ? DateTime.Parse((string)data["canceled_at"]) : null,
                discount: data.ContainsKey("discount") ? 
                    SubscriptionDiscount.From((Dictionary<string, object>)data["discount"]) : null,
                collectionMode: System.Enum.Parse<CollectionMode>((string)data["collection_mode"], true),
                billingDetails: data.ContainsKey("billing_details") ? 
                    BillingDetails.From((Dictionary<string, object>)data["billing_details"]) : null,
                currentBillingPeriod: data.ContainsKey("current_billing_period") ? 
                    SubscriptionTimePeriod.From((Dictionary<string, object>)data["current_billing_period"]) : null,
                billingCycle: TimePeriod.From((Dictionary<string, object>)data["billing_cycle"]),
                scheduledChange: data.ContainsKey("scheduled_change") ? 
                    SubscriptionScheduledChange.From((Dictionary<string, object>)data["scheduled_change"]) : null,
                managementUrls: data.ContainsKey("management_urls") ? 
                    SubscriptionManagementUrls.From((Dictionary<string, object>)data["management_urls"]) : null,
                items: items,
                customData: data.ContainsKey("custom_data") ? 
                    CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                immediateTransaction: data.ContainsKey("immediate_transaction") ? 
                    SubscriptionNextTransaction.From((Dictionary<string, object>)data["immediate_transaction"]) : null,
                nextTransaction: data.ContainsKey("next_transaction") ? 
                    SubscriptionNextTransaction.From((Dictionary<string, object>)data["next_transaction"]) : null,
                recurringTransactionDetails: data.ContainsKey("recurring_transaction_details") ? 
                    TransactionDetailsPreview.From((Dictionary<string, object>)data["recurring_transaction_details"]) : null,
                updateSummary: data.ContainsKey("update_summary") ? 
                    SubscriptionPreviewSubscriptionUpdateSummary.From((Dictionary<string, object>)data["update_summary"]) : null
            );
        }
    }
} 