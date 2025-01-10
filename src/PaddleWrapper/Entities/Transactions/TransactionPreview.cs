using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionPreview
    {
        public string CustomerId { get; }
        public string AddressId { get; }
        public string BusinessId { get; }
        public CurrencyCode CurrencyCode { get; }
        public string DiscountId { get; }
        public List<TransactionPreviewItem> Items { get; }
        public TransactionPreviewDetails Details { get; }
        public TransactionPreviewBillingDetails BillingDetails { get; }

        public TransactionPreview(
            string customerId,
            string addressId,
            string businessId,
            CurrencyCode currencyCode,
            string discountId,
            List<TransactionPreviewItem> items,
            TransactionPreviewDetails details,
            TransactionPreviewBillingDetails billingDetails)
        {
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode;
            DiscountId = discountId;
            Items = items;
            Details = details;
            BillingDetails = billingDetails;
        }

        public static TransactionPreview FromDict(JsonElement data)
        {
            return new TransactionPreview(
                customerId: data.GetProperty("customer_id").GetString(),
                addressId: data.GetProperty("address_id").GetString(),
                businessId: data.TryGetProperty("business_id", out var businessId) ? businessId.GetString() : null,
                currencyCode: Enum.Parse<CurrencyCode>(data.GetProperty("currency_code").GetString()),
                discountId: data.TryGetProperty("discount_id", out var discountId) ? discountId.GetString() : null,
                items: data.GetProperty("items").EnumerateArray()
                    .Select(TransactionPreviewItem.FromDict)
                    .ToList(),
                details: TransactionPreviewDetails.FromDict(data.GetProperty("details")),
                billingDetails: TransactionPreviewBillingDetails.FromDict(data.GetProperty("billing_details"))
            );
        }
    }
} 