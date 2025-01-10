using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Transactions
{
    /// <summary>
    /// Represents a transaction in the Paddle system
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The unique identifier for the transaction
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The status of the transaction
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The ID of the customer this transaction belongs to
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// The address ID used for the transaction
        /// </summary>
        [JsonProperty("address_id")]
        public string AddressId { get; set; }

        /// <summary>
        /// The business ID associated with the transaction
        /// </summary>
        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        /// <summary>
        /// The subscription ID associated with the transaction
        /// </summary>
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The currency code for the transaction
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The collection mode for the transaction
        /// </summary>
        [JsonProperty("collection_mode")]
        public string CollectionMode { get; set; }

        /// <summary>
        /// The billing details for the transaction
        /// </summary>
        [JsonProperty("billing_details")]
        public TransactionBillingDetails BillingDetails { get; set; }

        /// <summary>
        /// The items included in the transaction
        /// </summary>
        [JsonProperty("items")]
        public TransactionItem[] Items { get; set; }

        /// <summary>
        /// The details of the transaction
        /// </summary>
        [JsonProperty("details")]
        public TransactionDetails Details { get; set; }

        /// <summary>
        /// Custom data associated with the transaction
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// When the transaction was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the transaction was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// When the transaction was billed
        /// </summary>
        [JsonProperty("billed_at")]
        public DateTime? BilledAt { get; set; }
    }

    /// <summary>
    /// Represents billing details for a transaction
    /// </summary>
    public class TransactionBillingDetails
    {
        /// <summary>
        /// Enable prorating for billing changes
        /// </summary>
        [JsonProperty("enable_prorating")]
        public bool EnableProrating { get; set; }

        /// <summary>
        /// Payment terms in days
        /// </summary>
        [JsonProperty("payment_terms")]
        public object PaymentTerms { get; set; }

        /// <summary>
        /// Purchase order number
        /// </summary>
        [JsonProperty("purchase_order_number")]
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Additional information
        /// </summary>
        [JsonProperty("additional_information")]
        public string AdditionalInformation { get; set; }
    }

    /// <summary>
    /// Represents an item in a transaction
    /// </summary>
    public class TransactionItem
    {
        /// <summary>
        /// The price ID for this item
        /// </summary>
        [JsonProperty("price_id")]
        public string PriceId { get; set; }

        /// <summary>
        /// The quantity of this item
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The proration details for this item
        /// </summary>
        [JsonProperty("proration")]
        public ProrationDetails Proration { get; set; }
    }

    /// <summary>
    /// Represents proration details for a transaction item
    /// </summary>
    public class ProrationDetails
    {
        /// <summary>
        /// The rate applied for proration
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// The billing period for proration
        /// </summary>
        [JsonProperty("billing_period")]
        public BillingPeriod BillingPeriod { get; set; }
    }

    /// <summary>
    /// Represents a billing period
    /// </summary>
    public class BillingPeriod
    {
        /// <summary>
        /// Start date of the billing period
        /// </summary>
        [JsonProperty("starts_at")]
        public DateTime StartsAt { get; set; }

        /// <summary>
        /// End date of the billing period
        /// </summary>
        [JsonProperty("ends_at")]
        public DateTime EndsAt { get; set; }
    }

    /// <summary>
    /// Represents the details of a transaction
    /// </summary>
    public class TransactionDetails
    {
        /// <summary>
        /// The tax rates applied to the transaction
        /// </summary>
        [JsonProperty("tax_rates_used")]
        public TaxRate[] TaxRatesUsed { get; set; }

        /// <summary>
        /// The totals for the transaction
        /// </summary>
        [JsonProperty("totals")]
        public TransactionTotals Totals { get; set; }

        /// <summary>
        /// The line items in the transaction
        /// </summary>
        [JsonProperty("line_items")]
        public LineItem[] LineItems { get; set; }
    }

    /// <summary>
    /// Represents a tax rate used in a transaction
    /// </summary>
    public class TaxRate
    {
        /// <summary>
        /// The tax rate percentage
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// The tax rate name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Represents the totals for a transaction
    /// </summary>
    public class TransactionTotals
    {
        /// <summary>
        /// The subtotal amount
        /// </summary>
        [JsonProperty("subtotal")]
        public string Subtotal { get; set; }

        /// <summary>
        /// The discount amount
        /// </summary>
        [JsonProperty("discount")]
        public string Discount { get; set; }

        /// <summary>
        /// The tax amount
        /// </summary>
        [JsonProperty("tax")]
        public string Tax { get; set; }

        /// <summary>
        /// The total amount
        /// </summary>
        [JsonProperty("total")]
        public string Total { get; set; }
    }

    /// <summary>
    /// Represents a line item in a transaction
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// The ID of the price
        /// </summary>
        [JsonProperty("price_id")]
        public string PriceId { get; set; }

        /// <summary>
        /// The quantity of items
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The tax rate applied
        /// </summary>
        [JsonProperty("tax_rate")]
        public decimal TaxRate { get; set; }

        /// <summary>
        /// The unit price details
        /// </summary>
        [JsonProperty("unit_totals")]
        public UnitTotals UnitTotals { get; set; }

        /// <summary>
        /// The total price details
        /// </summary>
        [JsonProperty("totals")]
        public LineItemTotals Totals { get; set; }
    }

    /// <summary>
    /// Represents unit totals for a line item
    /// </summary>
    public class UnitTotals
    {
        /// <summary>
        /// The subtotal amount per unit
        /// </summary>
        [JsonProperty("subtotal")]
        public string Subtotal { get; set; }

        /// <summary>
        /// The discount amount per unit
        /// </summary>
        [JsonProperty("discount")]
        public string Discount { get; set; }

        /// <summary>
        /// The tax amount per unit
        /// </summary>
        [JsonProperty("tax")]
        public string Tax { get; set; }

        /// <summary>
        /// The total amount per unit
        /// </summary>
        [JsonProperty("total")]
        public string Total { get; set; }
    }

    /// <summary>
    /// Represents totals for a line item
    /// </summary>
    public class LineItemTotals
    {
        /// <summary>
        /// The subtotal amount
        /// </summary>
        [JsonProperty("subtotal")]
        public string Subtotal { get; set; }

        /// <summary>
        /// The discount amount
        /// </summary>
        [JsonProperty("discount")]
        public string Discount { get; set; }

        /// <summary>
        /// The tax amount
        /// </summary>
        [JsonProperty("tax")]
        public string Tax { get; set; }

        /// <summary>
        /// The total amount
        /// </summary>
        [JsonProperty("total")]
        public string Total { get; set; }
    }
}