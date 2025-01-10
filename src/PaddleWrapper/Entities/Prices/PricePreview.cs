using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Prices
{
    public class PricePreview
    {
        public string CustomerId { get; }
        public string AddressId { get; }
        public string BusinessId { get; }
        public CurrencyCode CurrencyCode { get; }
        public string DiscountId { get; }
        public List<PricePreviewItem> Items { get; }
        public PricePreviewDetails Details { get; }

        public PricePreview(
            string customerId,
            string addressId,
            string businessId,
            CurrencyCode currencyCode,
            string discountId,
            List<PricePreviewItem> items,
            PricePreviewDetails details)
        {
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode;
            DiscountId = discountId;
            Items = items;
            Details = details;
        }

        public static PricePreview FromDict(JsonElement data)
        {
            return new PricePreview(
                customerId: data.GetProperty("customer_id").GetString(),
                addressId: data.GetProperty("address_id").GetString(),
                businessId: data.TryGetProperty("business_id", out var businessId) ? businessId.GetString() : null,
                currencyCode: Enum.Parse<CurrencyCode>(data.GetProperty("currency_code").GetString()),
                discountId: data.TryGetProperty("discount_id", out var discountId) ? discountId.GetString() : null,
                items: data.GetProperty("items").EnumerateArray()
                    .Select(PricePreviewItem.FromDict)
                    .ToList(),
                details: PricePreviewDetails.FromDict(data.GetProperty("details"))
            );
        }
    }
} 