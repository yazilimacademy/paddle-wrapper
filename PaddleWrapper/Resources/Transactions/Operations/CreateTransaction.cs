using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Entities.Transaction;
using PaddleWrapper.Resources.Transactions.Operations.Create;

namespace PaddleWrapper.Resources.Transactions.Operations
{
    public class CreateTransaction
    {
        [JsonPropertyName("items")]
        public IEnumerable<TransactionCreateItem> Items { get; }

        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Status { get; }

        [JsonPropertyName("customer_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CustomerId { get; }

        [JsonPropertyName("address_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AddressId { get; }

        [JsonPropertyName("business_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BusinessId { get; }

        [JsonPropertyName("custom_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomData CustomData { get; }

        [JsonPropertyName("currency_code")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CurrencyCode { get; }

        [JsonPropertyName("collection_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CollectionMode { get; }

        [JsonPropertyName("discount_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DiscountId { get; }

        [JsonPropertyName("billing_details")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BillingDetails BillingDetails { get; }

        [JsonPropertyName("billing_period")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TransactionTimePeriod BillingPeriod { get; }

        [JsonPropertyName("checkout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Checkout Checkout { get; }

        public CreateTransaction(
            IEnumerable<TransactionCreateItem> items,
            TransactionStatus? status = null,
            string customerId = null,
            string addressId = null,
            string businessId = null,
            CustomData customData = null,
            CurrencyCode? currencyCode = null,
            CollectionMode? collectionMode = null,
            string discountId = null,
            BillingDetails billingDetails = null,
            TransactionTimePeriod billingPeriod = null,
            Checkout checkout = null)
        {
            Items = items;
            Status = status?.ToString().ToLower();
            CustomerId = customerId;
            AddressId = addressId;
            BusinessId = businessId;
            CustomData = customData;
            CurrencyCode = currencyCode?.ToString();
            CollectionMode = collectionMode?.ToString().ToLower();
            DiscountId = discountId;
            BillingDetails = billingDetails;
            BillingPeriod = billingPeriod;
            Checkout = checkout;
        }
    }
} 