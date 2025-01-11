using PaddleWrapper.Entities.PricingPreview;
using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class PricePreview
    {
        [JsonPropertyName("customer_id")]
        public string? CustomerId { get; }

        [JsonPropertyName("address_id")]
        public string? AddressId { get; }

        [JsonPropertyName("business_id")]
        public string? BusinessId { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        [JsonPropertyName("discount_id")]
        public string? DiscountId { get; }

        [JsonPropertyName("address")]
        public AddressPreview? Address { get; }

        [JsonPropertyName("customer_ip_address")]
        public string? CustomerIpAddress { get; }

        [JsonPropertyName("details")]
        public PricePreviewDetails Details { get; }

        [JsonPropertyName("available_payment_methods")]
        public IReadOnlyList<AvailablePaymentMethods> AvailablePaymentMethods { get; }

        private PricePreview(
            string? customerId,
            string? addressId,
            string? businessId,
            CurrencyCode currencyCode,
            string? discountId,
            AddressPreview? address,
            string? customerIpAddress,
            PricePreviewDetails details,
            IReadOnlyList<AvailablePaymentMethods> availablePaymentMethods)
        {
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode;
            DiscountId = discountId;
            Address = address;
            CustomerIpAddress = customerIpAddress;
            Details = details;
            AvailablePaymentMethods = availablePaymentMethods;
        }

        public static PricePreview From(Dictionary<string, object> data)
        {
            List<AvailablePaymentMethods> availablePaymentMethods = new();
            if (data.ContainsKey("available_payment_methods"))
            {
                object[] methodsData = (object[])data["available_payment_methods"];
                foreach (object method in methodsData)
                {
                    availablePaymentMethods.Add(System.Enum.Parse<AvailablePaymentMethods>((string)method, true));
                }
            }

            return new PricePreview(
                customerId: data.ContainsKey("customer_id") ? (string?)data["customer_id"] : null,
                addressId: data.ContainsKey("address_id") ? (string?)data["address_id"] : null,
                businessId: data.ContainsKey("business_id") ? (string?)data["business_id"] : null,
                currencyCode: System.Enum.Parse<CurrencyCode>((string)data["currency_code"], true),
                discountId: data.ContainsKey("discount_id") ? (string?)data["discount_id"] : null,
                address: data.ContainsKey("address") ?
                    AddressPreview.From((Dictionary<string, object>)data["address"]) : null,
                customerIpAddress: data.ContainsKey("customer_ip_address") ?
                    (string?)data["customer_ip_address"] : null,
                details: PricePreviewDetails.From((Dictionary<string, object>)data["details"]),
                availablePaymentMethods: availablePaymentMethods
            );
        }
    }
}