using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Transactions.Operations.Preview;

namespace PaddleWrapper.Resources.Transactions.Operations
{
    public class PreviewTransaction
    {
        [JsonPropertyName("items")]
        public IEnumerable<TransactionItemPreviewWithPriceId> Items { get; }

        [JsonPropertyName("customer_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CustomerId { get; }

        [JsonPropertyName("address_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AddressId { get; }

        [JsonPropertyName("business_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BusinessId { get; }

        [JsonPropertyName("currency_code")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CurrencyCode { get; }

        [JsonPropertyName("collection_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CollectionMode { get; }

        [JsonPropertyName("discount_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DiscountId { get; }

        [JsonPropertyName("customer_ip_address")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CustomerIpAddress { get; }

        [JsonPropertyName("address")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AddressPreview Address { get; }

        [JsonPropertyName("ignore_trials")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreTrials { get; }

        public PreviewTransaction(
            IEnumerable<TransactionItemPreviewWithPriceId> items,
            string customerId = null,
            string addressId = null,
            string businessId = null,
            CurrencyCode? currencyCode = null,
            CollectionMode? collectionMode = null,
            string discountId = null,
            string customerIpAddress = null,
            AddressPreview address = null,
            bool? ignoreTrials = null)
        {
            Items = items;
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CurrencyCode = currencyCode?.ToString();
            CollectionMode = collectionMode?.ToString().ToLower();
            DiscountId = discountId;
            CustomerIpAddress = customerIpAddress;
            Address = address;
            IgnoreTrials = ignoreTrials;
        }
    }
} 