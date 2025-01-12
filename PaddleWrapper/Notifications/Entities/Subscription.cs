using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Shared;
using PaddleWrapper.Notifications.Entities.Subscriptions;

namespace PaddleWrapper.Notifications.Entities;

public class Subscription : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; }

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

    [JsonPropertyName("items")]
    public IReadOnlyList<SubscriptionItem> Items { get; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; }

    private Subscription(
        string id,
        string? transactionId,
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
        IReadOnlyList<SubscriptionItem> items,
        CustomData? customData,
        ImportMeta? importMeta)
    {
        Id = id;
        TransactionId = transactionId;
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
        Items = items;
        CustomData = customData;
        ImportMeta = importMeta;
    }

    public static IEntity FromJson(JsonElement json)
    {
        var items = new List<SubscriptionItem>();
        if (json.TryGetProperty("items", out var itemsElement))
        {
            foreach (var item in itemsElement.EnumerateArray())
            {
                items.Add(SubscriptionItem.FromJson(item));
            }
        }

        return new Subscription(
            id: json.GetProperty("id").GetString()!,
            transactionId: json.TryGetProperty("transaction_id", out var transactionIdElement) ? transactionIdElement.GetString() : null,
            status: JsonSerializer.Deserialize<SubscriptionStatus>(json.GetProperty("status").GetRawText())!,
            customerId: json.GetProperty("customer_id").GetString()!,
            addressId: json.GetProperty("address_id").GetString()!,
            businessId: json.TryGetProperty("business_id", out var businessIdElement) ? businessIdElement.GetString() : null,
            currencyCode: JsonSerializer.Deserialize<CurrencyCode>(json.GetProperty("currency_code").GetRawText())!,
            createdAt: DateTime.Parse(json.GetProperty("created_at").GetString()!),
            updatedAt: DateTime.Parse(json.GetProperty("updated_at").GetString()!),
            startedAt: json.TryGetProperty("started_at", out var startedAtElement) 
                ? DateTime.Parse(startedAtElement.GetString()!) 
                : null,
            firstBilledAt: json.TryGetProperty("first_billed_at", out var firstBilledAtElement) 
                ? DateTime.Parse(firstBilledAtElement.GetString()!) 
                : null,
            nextBilledAt: json.TryGetProperty("next_billed_at", out var nextBilledAtElement) 
                ? DateTime.Parse(nextBilledAtElement.GetString()!) 
                : null,
            pausedAt: json.TryGetProperty("paused_at", out var pausedAtElement) 
                ? DateTime.Parse(pausedAtElement.GetString()!) 
                : null,
            canceledAt: json.TryGetProperty("canceled_at", out var canceledAtElement) 
                ? DateTime.Parse(canceledAtElement.GetString()!) 
                : null,
            discount: json.TryGetProperty("discount", out var discountElement) 
                ? SubscriptionDiscount.FromJson(discountElement) 
                : null,
            collectionMode: JsonSerializer.Deserialize<CollectionMode>(json.GetProperty("collection_mode").GetRawText())!,
            billingDetails: json.TryGetProperty("billing_details", out var billingDetailsElement) 
                ? BillingDetails.FromJson(billingDetailsElement) 
                : null,
            currentBillingPeriod: json.TryGetProperty("current_billing_period", out var currentBillingPeriodElement) 
                ? SubscriptionTimePeriod.FromJson(currentBillingPeriodElement) 
                : null,
            billingCycle: TimePeriod.FromJson(json.GetProperty("billing_cycle")),
            scheduledChange: json.TryGetProperty("scheduled_change", out var scheduledChangeElement) 
                ? SubscriptionScheduledChange.FromJson(scheduledChangeElement) 
                : null,
            items: items,
            customData: json.TryGetProperty("custom_data", out var customDataElement) 
                ? CustomData.FromJson(customDataElement) 
                : null,
            importMeta: json.TryGetProperty("import_meta", out var importMetaElement) 
                ? ImportMeta.FromJson(importMetaElement) 
                : null
        );
    }
} 