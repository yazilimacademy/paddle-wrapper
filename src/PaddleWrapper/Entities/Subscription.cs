using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class Subscription : Entity
    {
        public string Status { get; }
        public string CustomerId { get; }
        public string AddressId { get; }
        public string BusinessId { get; }
        public CurrencyCode CurrencyCode { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public DateTime? StartedAt { get; }
        public DateTime? FirstBilledAt { get; }
        public DateTime? NextBilledAt { get; }
        public DateTime? PausedAt { get; }
        public DateTime? CanceledAt { get; }
        public DiscountInfo Discount { get; }
        public CollectionMode CollectionMode { get; }
        public BillingDetails BillingDetails { get; }
        public CurrentBillingPeriod CurrentBillingPeriod { get; }
        public ScheduledChange ScheduledChange { get; }
        public List<Item> Items { get; }
        public CustomData CustomData { get; }
        public ImportMeta ImportMeta { get; }

        public Subscription(
            string id,
            string status,
            string customerId,
            string addressId,
            string businessId,
            CurrencyCode currencyCode,
            DateTime createdAt,
            DateTime updatedAt,
            DateTime? startedAt,
            DateTime? firstBilledAt,
            DateTime? nextBilledAt,
            DateTime? pausedAt,
            DateTime? canceledAt,
            DiscountInfo discount,
            CollectionMode collectionMode,
            BillingDetails billingDetails,
            CurrentBillingPeriod currentBillingPeriod,
            ScheduledChange scheduledChange,
            List<Item> items,
            CustomData customData,
            ImportMeta importMeta)
        {
            Id = id;
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
            ScheduledChange = scheduledChange;
            Items = items;
            CustomData = customData;
            ImportMeta = importMeta;
        }

        public static Subscription FromDict(JsonElement data)
        {
            return new Subscription(
                id: data.GetProperty("id").GetString(),
                status: data.GetProperty("status").GetString(),
                customerId: data.GetProperty("customer_id").GetString(),
                addressId: data.GetProperty("address_id").GetString(),
                businessId: data.TryGetProperty("business_id", out var businessId) ? businessId.GetString() : null,
                currencyCode: Enum.Parse<CurrencyCode>(data.GetProperty("currency_code").GetString()),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString()),
                startedAt: data.TryGetProperty("started_at", out var startedAt) ? DateTime.Parse(startedAt.GetString()) : null,
                firstBilledAt: data.TryGetProperty("first_billed_at", out var firstBilledAt) ? DateTime.Parse(firstBilledAt.GetString()) : null,
                nextBilledAt: data.TryGetProperty("next_billed_at", out var nextBilledAt) ? DateTime.Parse(nextBilledAt.GetString()) : null,
                pausedAt: data.TryGetProperty("paused_at", out var pausedAt) ? DateTime.Parse(pausedAt.GetString()) : null,
                canceledAt: data.TryGetProperty("canceled_at", out var canceledAt) ? DateTime.Parse(canceledAt.GetString()) : null,
                discount: data.TryGetProperty("discount", out var discount) ? DiscountInfo.FromDict(discount) : null,
                collectionMode: CollectionMode.FromDict(data.GetProperty("collection_mode")),
                billingDetails: BillingDetails.FromDict(data.GetProperty("billing_details")),
                currentBillingPeriod: CurrentBillingPeriod.FromDict(data.GetProperty("current_billing_period")),
                scheduledChange: data.TryGetProperty("scheduled_change", out var scheduledChange) ? ScheduledChange.FromDict(scheduledChange) : null,
                items: data.GetProperty("items").EnumerateArray().Select(Item.FromDict).ToList(),
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                importMeta: data.TryGetProperty("import_meta", out var importMeta) ? ImportMeta.FromDict(importMeta) : null
            );
        }
    }
} 