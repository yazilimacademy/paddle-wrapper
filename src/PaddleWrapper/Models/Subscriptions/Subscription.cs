using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Subscriptions
{
    /// <summary>
    /// Represents a subscription in the Paddle system
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// The unique identifier for the subscription
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The status of the subscription
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The ID of the customer this subscription belongs to
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// The address ID used for the subscription
        /// </summary>
        [JsonProperty("address_id")]
        public string AddressId { get; set; }

        /// <summary>
        /// The business ID associated with the subscription
        /// </summary>
        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        /// <summary>
        /// The currency code for the subscription
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The next billed amount
        /// </summary>
        [JsonProperty("next_billed_amount")]
        public string NextBilledAmount { get; set; }

        /// <summary>
        /// The next billed at date
        /// </summary>
        [JsonProperty("next_billed_at")]
        public DateTime? NextBilledAt { get; set; }

        /// <summary>
        /// The first billed at date
        /// </summary>
        [JsonProperty("first_billed_at")]
        public DateTime FirstBilledAt { get; set; }

        /// <summary>
        /// The last billed at date
        /// </summary>
        [JsonProperty("last_billed_at")]
        public DateTime? LastBilledAt { get; set; }

        /// <summary>
        /// The paused at date
        /// </summary>
        [JsonProperty("paused_at")]
        public DateTime? PausedAt { get; set; }

        /// <summary>
        /// The canceled at date
        /// </summary>
        [JsonProperty("canceled_at")]
        public DateTime? CanceledAt { get; set; }

        /// <summary>
        /// Collection mode for the subscription
        /// </summary>
        [JsonProperty("collection_mode")]
        public string CollectionMode { get; set; }

        /// <summary>
        /// Billing details for the subscription
        /// </summary>
        [JsonProperty("billing_details")]
        public BillingDetails BillingDetails { get; set; }

        /// <summary>
        /// Current billing period for the subscription
        /// </summary>
        [JsonProperty("current_billing_period")]
        public BillingPeriod CurrentBillingPeriod { get; set; }

        /// <summary>
        /// Items included in the subscription
        /// </summary>
        [JsonProperty("items")]
        public SubscriptionItem[] Items { get; set; }

        /// <summary>
        /// Custom data associated with the subscription
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// Management URLs for the subscription
        /// </summary>
        [JsonProperty("management_urls")]
        public ManagementUrls ManagementUrls { get; set; }

        /// <summary>
        /// Scheduled changes for the subscription
        /// </summary>
        [JsonProperty("scheduled_change")]
        public ScheduledChange ScheduledChange { get; set; }

        /// <summary>
        /// When the subscription was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the subscription was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Represents billing details for a subscription
    /// </summary>
    public class BillingDetails
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
    /// Represents an item in a subscription
    /// </summary>
    public class SubscriptionItem
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
        /// Whether this item is recurring
        /// </summary>
        [JsonProperty("recurring")]
        public bool Recurring { get; set; }

        /// <summary>
        /// The status of this item
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// Represents management URLs for a subscription
    /// </summary>
    public class ManagementUrls
    {
        /// <summary>
        /// URL for updating payment details
        /// </summary>
        [JsonProperty("update_payment_method")]
        public string UpdatePaymentMethod { get; set; }

        /// <summary>
        /// URL for canceling the subscription
        /// </summary>
        [JsonProperty("cancel")]
        public string Cancel { get; set; }
    }

    /// <summary>
    /// Represents a scheduled change for a subscription
    /// </summary>
    public class ScheduledChange
    {
        /// <summary>
        /// The action to be performed
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// When the change is scheduled for
        /// </summary>
        [JsonProperty("scheduled_at")]
        public DateTime ScheduledAt { get; set; }

        /// <summary>
        /// Whether to resume immediately
        /// </summary>
        [JsonProperty("resume_at")]
        public DateTime? ResumeAt { get; set; }

        /// <summary>
        /// The effective from date
        /// </summary>
        [JsonProperty("effective_from")]
        public DateTime EffectiveFrom { get; set; }
    }
}