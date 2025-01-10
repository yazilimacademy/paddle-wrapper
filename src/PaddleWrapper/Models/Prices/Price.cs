using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Prices
{
    /// <summary>
    /// Represents a price in the Paddle system
    /// </summary>
    public class Price
    {
        /// <summary>
        /// The unique identifier for the price
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the product this price belongs to
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// The description of the price
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The billing cycle configuration
        /// </summary>
        [JsonProperty("billing_cycle")]
        public BillingCycle BillingCycle { get; set; }

        /// <summary>
        /// The trial period configuration
        /// </summary>
        [JsonProperty("trial")]
        public Trial Trial { get; set; }

        /// <summary>
        /// The tax mode for this price
        /// </summary>
        [JsonProperty("tax_mode")]
        public string TaxMode { get; set; }

        /// <summary>
        /// The unit price details
        /// </summary>
        [JsonProperty("unit_price")]
        public UnitPrice UnitPrice { get; set; }

        /// <summary>
        /// The quantity configuration
        /// </summary>
        [JsonProperty("quantity")]
        public Quantity Quantity { get; set; }

        /// <summary>
        /// Custom data associated with the price
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// The status of the price
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// When the price was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the price was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Represents billing cycle configuration
    /// </summary>
    public class BillingCycle
    {
        /// <summary>
        /// The billing interval
        /// </summary>
        [JsonProperty("interval")]
        public string Interval { get; set; }

        /// <summary>
        /// The frequency of billing
        /// </summary>
        [JsonProperty("frequency")]
        public int Frequency { get; set; }
    }

    /// <summary>
    /// Represents trial period configuration
    /// </summary>
    public class Trial
    {
        /// <summary>
        /// The trial interval
        /// </summary>
        [JsonProperty("interval")]
        public string Interval { get; set; }

        /// <summary>
        /// The frequency of the trial period
        /// </summary>
        [JsonProperty("frequency")]
        public int Frequency { get; set; }
    }

    /// <summary>
    /// Represents unit price details
    /// </summary>
    public class UnitPrice
    {
        /// <summary>
        /// The amount in the smallest currency unit
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The currency code
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }

    /// <summary>
    /// Represents quantity configuration
    /// </summary>
    public class Quantity
    {
        /// <summary>
        /// The minimum quantity
        /// </summary>
        [JsonProperty("minimum")]
        public int Minimum { get; set; }

        /// <summary>
        /// The maximum quantity
        /// </summary>
        [JsonProperty("maximum")]
        public int? Maximum { get; set; }
    }
}