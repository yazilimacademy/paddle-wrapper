using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Shared;
using PaddleWrapper.Notifications.Entities.Transaction;

namespace PaddleWrapper.Notifications.Entities;

public class Transaction : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("status")]
    public TransactionStatus Status { get; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; }

    [JsonPropertyName("address_id")]
    public string? AddressId { get; }

    [JsonPropertyName("business_id")]
    public string? BusinessId { get; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode CurrencyCode { get; }

    [JsonPropertyName("origin")]
    public TransactionOrigin Origin { get; }

    [JsonPropertyName("subscription_id")]
    public string? SubscriptionId { get; }

    [JsonPropertyName("invoice_id")]
    public string? InvoiceId { get; }

    [JsonPropertyName("invoice_number")]
    public string? InvoiceNumber { get; }

    [JsonPropertyName("collection_mode")]
    public CollectionMode CollectionMode { get; }

    [JsonPropertyName("discount_id")]
    public string? DiscountId { get; }

    [JsonPropertyName("billing_details")]
    public BillingDetails? BillingDetails { get; }

    [JsonPropertyName("billing_period")]
    public TransactionTimePeriod? BillingPeriod { get; }

    [JsonPropertyName("items")]
    public IReadOnlyList<TransactionItem> Items { get; }

    [JsonPropertyName("details")]
    public TransactionDetails Details { get; }

    [JsonPropertyName("payments")]
    public IReadOnlyList<TransactionPaymentAttempt> Payments { get; }

    [JsonPropertyName("checkout")]
    public Checkout? Checkout { get; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; }

    [JsonPropertyName("billed_at")]
    public DateTime? BilledAt { get; }

    private Transaction(
        string id,
        TransactionStatus status,
        string? customerId,
        string? addressId,
        string? businessId,
        CustomData? customData,
        CurrencyCode currencyCode,
        TransactionOrigin origin,
        string? subscriptionId,
        string? invoiceId,
        string? invoiceNumber,
        CollectionMode collectionMode,
        string? discountId,
        BillingDetails? billingDetails,
        TransactionTimePeriod? billingPeriod,
        IReadOnlyList<TransactionItem> items,
        TransactionDetails details,
        IReadOnlyList<TransactionPaymentAttempt> payments,
        Checkout? checkout,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime? billedAt)
    {
        Id = id;
        Status = status;
        CustomerId = customerId;
        AddressId = addressId;
        BusinessId = businessId;
        CustomData = customData;
        CurrencyCode = currencyCode;
        Origin = origin;
        SubscriptionId = subscriptionId;
        InvoiceId = invoiceId;
        InvoiceNumber = invoiceNumber;
        CollectionMode = collectionMode;
        DiscountId = discountId;
        BillingDetails = billingDetails;
        BillingPeriod = billingPeriod;
        Items = items;
        Details = details;
        Payments = payments;
        Checkout = checkout;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        BilledAt = billedAt;
    }

    public static IEntity FromJson(JsonElement json)
    {
        var items = new List<TransactionItem>();
        if (json.TryGetProperty("items", out var itemsElement))
        {
            foreach (var item in itemsElement.EnumerateArray())
            {
                items.Add(TransactionItem.FromJson(item));
            }
        }

        var payments = new List<TransactionPaymentAttempt>();
        if (json.TryGetProperty("payments", out var paymentsElement))
        {
            foreach (var payment in paymentsElement.EnumerateArray())
            {
                payments.Add(TransactionPaymentAttempt.FromJson(payment));
            }
        }

        return new Transaction(
            id: json.GetProperty("id").GetString()!,
            status: JsonSerializer.Deserialize<TransactionStatus>(json.GetProperty("status").GetRawText())!,
            customerId: json.TryGetProperty("customer_id", out var customerIdElement) ? customerIdElement.GetString() : null,
            addressId: json.TryGetProperty("address_id", out var addressIdElement) ? addressIdElement.GetString() : null,
            businessId: json.TryGetProperty("business_id", out var businessIdElement) ? businessIdElement.GetString() : null,
            customData: json.TryGetProperty("custom_data", out var customDataElement) 
                ? CustomData.FromJson(customDataElement) 
                : null,
            currencyCode: JsonSerializer.Deserialize<CurrencyCode>(json.GetProperty("currency_code").GetRawText())!,
            origin: JsonSerializer.Deserialize<TransactionOrigin>(json.GetProperty("origin").GetRawText())!,
            subscriptionId: json.TryGetProperty("subscription_id", out var subscriptionIdElement) ? subscriptionIdElement.GetString() : null,
            invoiceId: json.TryGetProperty("invoice_id", out var invoiceIdElement) ? invoiceIdElement.GetString() : null,
            invoiceNumber: json.TryGetProperty("invoice_number", out var invoiceNumberElement) ? invoiceNumberElement.GetString() : null,
            collectionMode: JsonSerializer.Deserialize<CollectionMode>(json.GetProperty("collection_mode").GetRawText())!,
            discountId: json.TryGetProperty("discount_id", out var discountIdElement) ? discountIdElement.GetString() : null,
            billingDetails: json.TryGetProperty("billing_details", out var billingDetailsElement) 
                ? BillingDetails.FromJson(billingDetailsElement) 
                : null,
            billingPeriod: json.TryGetProperty("billing_period", out var billingPeriodElement) 
                ? TransactionTimePeriod.FromJson(billingPeriodElement) 
                : null,
            items: items,
            details: TransactionDetails.FromJson(json.GetProperty("details")),
            payments: payments,
            checkout: json.TryGetProperty("checkout", out var checkoutElement) 
                ? Checkout.FromJson(checkoutElement) 
                : null,
            createdAt: DateTime.Parse(json.GetProperty("created_at").GetString()!),
            updatedAt: DateTime.Parse(json.GetProperty("updated_at").GetString()!),
            billedAt: json.TryGetProperty("billed_at", out var billedAtElement) 
                ? DateTime.Parse(billedAtElement.GetString()!) 
                : null
        );
    }
} 