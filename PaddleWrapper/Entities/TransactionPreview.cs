using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Entities.Transactions;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class TransactionPreview
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

        [JsonPropertyName("customer_ip_address")]
        public string? CustomerIpAddress { get; }

        [JsonPropertyName("address")]
        public AddressPreview? Address { get; }

        [JsonPropertyName("ignore_trials")]
        public bool IgnoreTrials { get; }

        [JsonPropertyName("items")]
        public IReadOnlyList<TransactionItemPreviewWithPrice> Items { get; }

        [JsonPropertyName("details")]
        public TransactionDetailsPreview Details { get; }

        [JsonPropertyName("available_payment_methods")]
        public IReadOnlyList<AvailablePaymentMethods> AvailablePaymentMethods { get; }

        private TransactionPreview(
            string? customerId,
            string? addressId,
            string? businessId,
            CurrencyCode currencyCode,
            string? discountId,
            string? customerIpAddress,
            AddressPreview? address,
            bool ignoreTrials,
            IReadOnlyList<TransactionItemPreviewWithPrice> items,
            TransactionDetailsPreview details,
            IReadOnlyList<AvailablePaymentMethods> availablePaymentMethods)
        {
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode;
            DiscountId = discountId;
            CustomerIpAddress = customerIpAddress;
            Address = address;
            IgnoreTrials = ignoreTrials;
            Items = items;
            Details = details;
            AvailablePaymentMethods = availablePaymentMethods;
        }

        public static TransactionPreview From(Dictionary<string, object> data)
        {
            List<TransactionItemPreviewWithPrice> items = new();
            if (data.ContainsKey("items"))
            {
                object[] itemsData = (object[])data["items"];
                foreach (object item in itemsData)
                {
                    items.Add(TransactionItemPreviewWithPrice.From((Dictionary<string, object>)item));
                }
            }

            List<AvailablePaymentMethods> availablePaymentMethods = new();
            if (data.ContainsKey("available_payment_methods"))
            {
                object[] methodsData = (object[])data["available_payment_methods"];
                foreach (object method in methodsData)
                {
                    availablePaymentMethods.Add(Enum.Parse<AvailablePaymentMethods>((string)method, true));
                }
            }

            return new TransactionPreview(
                customerId: data.ContainsKey("customer_id") ? (string?)data["customer_id"] : null,
                addressId: data.ContainsKey("address_id") ? (string?)data["address_id"] : null,
                businessId: data.ContainsKey("business_id") ? (string?)data["business_id"] : null,
                currencyCode: Enum.Parse<CurrencyCode>((string)data["currency_code"], true),
                discountId: data.ContainsKey("discount_id") ? (string?)data["discount_id"] : null,
                customerIpAddress: data.ContainsKey("customer_ip_address") ? (string?)data["customer_ip_address"] : null,
                address: data.ContainsKey("address") ?
                    AddressPreview.From((Dictionary<string, object>)data["address"]) : null,
                ignoreTrials: (bool)data["ignore_trials"],
                items: items,
                details: TransactionDetailsPreview.From((Dictionary<string, object>)data["details"]),
                availablePaymentMethods: availablePaymentMethods
            );
        }
    }
}