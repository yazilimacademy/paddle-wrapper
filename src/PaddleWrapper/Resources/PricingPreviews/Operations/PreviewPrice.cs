using PaddleWrapper.Entities.PricingPreview;
using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.PricingPreviews.Operations
{
    public class PreviewPrice
    {
        [JsonPropertyName("items")]
        public IEnumerable<PricePreviewItem> Items { get; }

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
        public CurrencyCode? CurrencyCode { get; }

        [JsonPropertyName("discount_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DiscountId { get; }

        [JsonPropertyName("address")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AddressPreview? Address { get; }

        [JsonPropertyName("customer_ip_address")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CustomerIpAddress { get; }

        public PreviewPrice(
            IEnumerable<PricePreviewItem> items,
            string? customerId = null,
            string? addressId = null,
            string? businessId = null,
            CurrencyCode? currencyCode = null,
            string? discountId = null,
            AddressPreview? address = null,
            string? customerIpAddress = null)
        {
            List<PricePreviewItem> itemsList = items?.ToList() ?? new List<PricePreviewItem>();

            if (!itemsList.Any())
            {
                throw new ArgumentException("items cannot be empty", nameof(items));
            }

            if (itemsList.Any(item => item == null))
            {
                throw new ArgumentException("items cannot contain null values", nameof(items));
            }

            Items = itemsList;
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode;
            DiscountId = discountId;
            Address = address;
            CustomerIpAddress = customerIpAddress;
        }
    }
}