using System.Text.Json;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Entities.Transactions;

namespace PaddleWrapper.Entities
{
    public class Transaction : Entity
    {
        public string Status { get; }
        public string CustomerId { get; }
        public string AddressId { get; }
        public string BusinessId { get; }
        public CurrencyCode CurrencyCode { get; }
        public List<TransactionItem> Items { get; }
        public TransactionDetails Details { get; }
        public List<TransactionPayment> Payments { get; }
        public TransactionBillingDetails BillingDetails { get; }
        public CustomData CustomData { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public DateTime? BilledAt { get; }
        public string SubscriptionId { get; }
        public string InvoiceNumber { get; }
        public string InvoiceId { get; }

        public Transaction(
            string id,
            string status,
            string customerId,
            string addressId,
            string businessId,
            CurrencyCode currencyCode,
            List<TransactionItem> items,
            TransactionDetails details,
            List<TransactionPayment> payments,
            TransactionBillingDetails billingDetails,
            CustomData customData,
            DateTime createdAt,
            DateTime updatedAt,
            DateTime? billedAt,
            string subscriptionId,
            string invoiceNumber,
            string invoiceId)
        {
            Id = id;
            Status = status;
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode;
            Items = items;
            Details = details;
            Payments = payments;
            BillingDetails = billingDetails;
            CustomData = customData;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            BilledAt = billedAt;
            SubscriptionId = subscriptionId;
            InvoiceNumber = invoiceNumber;
            InvoiceId = invoiceId;
        }

        public static Transaction FromDict(JsonElement data)
        {
            return new Transaction(
                id: data.GetProperty("id").GetString(),
                status: data.GetProperty("status").GetString(),
                customerId: data.GetProperty("customer_id").GetString(),
                addressId: data.GetProperty("address_id").GetString(),
                businessId: data.TryGetProperty("business_id", out var businessId) ? businessId.GetString() : null,
                currencyCode: Enum.Parse<CurrencyCode>(data.GetProperty("currency_code").GetString()),
                items: data.GetProperty("items").EnumerateArray()
                    .Select(TransactionItem.FromDict)
                    .ToList(),
                details: TransactionDetails.FromDict(data.GetProperty("details")),
                payments: data.GetProperty("payments").EnumerateArray()
                    .Select(TransactionPayment.FromDict)
                    .ToList(),
                billingDetails: TransactionBillingDetails.FromDict(data.GetProperty("billing_details")),
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString()),
                billedAt: data.TryGetProperty("billed_at", out var billedAt) ? DateTime.Parse(billedAt.GetString()) : null,
                subscriptionId: data.TryGetProperty("subscription_id", out var subId) ? subId.GetString() : null,
                invoiceNumber: data.TryGetProperty("invoice_number", out var invNum) ? invNum.GetString() : null,
                invoiceId: data.TryGetProperty("invoice_id", out var invId) ? invId.GetString() : null
            );
        }
    }
} 