using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Entities.Transactions;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class Transaction
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

        [JsonPropertyName("address")]
        public Address? Address { get; }

        [JsonPropertyName("adjustments")]
        public IReadOnlyList<Adjustment> Adjustments { get; }

        [JsonPropertyName("adjustments_totals")]
        public TransactionAdjustmentsTotals? AdjustmentsTotals { get; }

        [JsonPropertyName("business")]
        public Business? Business { get; }

        [JsonPropertyName("customer")]
        public Customer? Customer { get; }

        [JsonPropertyName("discount")]
        public Discount? Discount { get; }

        [JsonPropertyName("available_payment_methods")]
        public IReadOnlyList<AvailablePaymentMethods> AvailablePaymentMethods { get; }

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
            DateTime? billedAt,
            Address? address,
            IReadOnlyList<Adjustment> adjustments,
            TransactionAdjustmentsTotals? adjustmentsTotals,
            Business? business,
            Customer? customer,
            Discount? discount,
            IReadOnlyList<AvailablePaymentMethods> availablePaymentMethods)
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
            Address = address;
            Adjustments = adjustments;
            AdjustmentsTotals = adjustmentsTotals;
            Business = business;
            Customer = customer;
            Discount = discount;
            AvailablePaymentMethods = availablePaymentMethods;
        }

        public static Transaction From(Dictionary<string, object> data)
        {
            List<TransactionItem> items = new();
            if (data.ContainsKey("items"))
            {
                object[] itemsData = (object[])data["items"];
                foreach (object item in itemsData)
                {
                    items.Add(TransactionItem.From((Dictionary<string, object>)item));
                }
            }

            List<TransactionPaymentAttempt> payments = new();
            if (data.ContainsKey("payments"))
            {
                object[] paymentsData = (object[])data["payments"];
                foreach (object payment in paymentsData)
                {
                    payments.Add(TransactionPaymentAttempt.From((Dictionary<string, object>)payment));
                }
            }

            List<Adjustment> adjustments = new();
            if (data.ContainsKey("adjustments"))
            {
                object[] adjustmentsData = (object[])data["adjustments"];
                foreach (object adjustment in adjustmentsData)
                {
                    adjustments.Add(Adjustment.From((Dictionary<string, object>)adjustment));
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

            return new Transaction(
                id: (string)data["id"],
                status: Enum.Parse<TransactionStatus>((string)data["status"], true),
                customerId: data.ContainsKey("customer_id") ? (string?)data["customer_id"] : null,
                addressId: data.ContainsKey("address_id") ? (string?)data["address_id"] : null,
                businessId: data.ContainsKey("business_id") ? (string?)data["business_id"] : null,
                customData: data.ContainsKey("custom_data") ?
                    CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                currencyCode: Enum.Parse<CurrencyCode>((string)data["currency_code"], true),
                origin: Enum.Parse<TransactionOrigin>((string)data["origin"], true),
                subscriptionId: data.ContainsKey("subscription_id") ? (string?)data["subscription_id"] : null,
                invoiceId: data.ContainsKey("invoice_id") ? (string?)data["invoice_id"] : null,
                invoiceNumber: data.ContainsKey("invoice_number") ? (string?)data["invoice_number"] : null,
                collectionMode: Enum.Parse<CollectionMode>((string)data["collection_mode"], true),
                discountId: data.ContainsKey("discount_id") ? (string?)data["discount_id"] : null,
                billingDetails: data.ContainsKey("billing_details") ?
                    BillingDetails.From((Dictionary<string, object>)data["billing_details"]) : null,
                billingPeriod: data.ContainsKey("billing_period") ?
                    TransactionTimePeriod.From((Dictionary<string, object>)data["billing_period"]) : null,
                items: items,
                details: TransactionDetails.From((Dictionary<string, object>)data["details"]),
                payments: payments,
                checkout: data.ContainsKey("checkout") ?
                    Checkout.From((Dictionary<string, object>)data["checkout"]) : null,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"]),
                billedAt: data.ContainsKey("billed_at") ? DateTime.Parse((string)data["billed_at"]) : null,
                address: data.ContainsKey("address") ?
                    Address.From((Dictionary<string, object>)data["address"]) : null,
                adjustments: adjustments,
                adjustmentsTotals: data.ContainsKey("adjustments_totals") ?
                    TransactionAdjustmentsTotals.From((Dictionary<string, object>)data["adjustments_totals"]) : null,
                business: data.ContainsKey("business") ?
                    Business.From((Dictionary<string, object>)data["business"]) : null,
                customer: data.ContainsKey("customer") ?
                    Customer.From((Dictionary<string, object>)data["customer"]) : null,
                discount: data.ContainsKey("discount") ?
                    Discount.From((Dictionary<string, object>)data["discount"]) : null,
                availablePaymentMethods: availablePaymentMethods
            );
        }
    }
}