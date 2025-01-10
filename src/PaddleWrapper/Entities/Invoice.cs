using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class Invoice : Entity
    {
        public string Status { get; }
        public string CustomerId { get; }
        public string AddressId { get; }
        public string BusinessId { get; }
        public CurrencyCode CurrencyCode { get; }
        public List<InvoiceItem> Items { get; }
        public InvoiceDetails Details { get; }
        public InvoiceBillingDetails BillingDetails { get; }
        public CustomData CustomData { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public DateTime? BilledAt { get; }
        public string InvoiceNumber { get; }

        public Invoice(
            string id,
            string status,
            string customerId,
            string addressId,
            string businessId,
            CurrencyCode currencyCode,
            List<InvoiceItem> items,
            InvoiceDetails details,
            InvoiceBillingDetails billingDetails,
            CustomData customData,
            DateTime createdAt,
            DateTime updatedAt,
            DateTime? billedAt,
            string invoiceNumber)
        {
            Id = id;
            Status = status;
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode;
            Items = items;
            Details = details;
            BillingDetails = billingDetails;
            CustomData = customData;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            BilledAt = billedAt;
            InvoiceNumber = invoiceNumber;
        }

        public static Invoice FromDict(JsonElement data)
        {
            return new Invoice(
                id: data.GetProperty("id").GetString(),
                status: data.GetProperty("status").GetString(),
                customerId: data.GetProperty("customer_id").GetString(),
                addressId: data.GetProperty("address_id").GetString(),
                businessId: data.TryGetProperty("business_id", out var businessId) ? businessId.GetString() : null,
                currencyCode: Enum.Parse<CurrencyCode>(data.GetProperty("currency_code").GetString()),
                items: data.GetProperty("items").EnumerateArray()
                    .Select(InvoiceItem.FromDict)
                    .ToList(),
                details: InvoiceDetails.FromDict(data.GetProperty("details")),
                billingDetails: InvoiceBillingDetails.FromDict(data.GetProperty("billing_details")),
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString()),
                billedAt: data.TryGetProperty("billed_at", out var billedAt) ? DateTime.Parse(billedAt.GetString()) : null,
                invoiceNumber: data.GetProperty("invoice_number").GetString()
            );
        }
    }
} 