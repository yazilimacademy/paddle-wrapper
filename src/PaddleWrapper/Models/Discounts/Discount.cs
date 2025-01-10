using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Discounts
{
    /// <summary>
    /// Represents a discount in the Paddle system
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// The unique identifier for the discount
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The discount code that customers can use
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// The type of discount (percentage, fixed_amount)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The amount of the discount
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The currency code for fixed amount discounts
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Whether the discount is recurring for subscription payments
        /// </summary>
        [JsonProperty("is_recurring")]
        public bool IsRecurring { get; set; }

        /// <summary>
        /// The maximum number of times this discount can be used
        /// </summary>
        [JsonProperty("usage_limit")]
        public int? UsageLimit { get; set; }

        /// <summary>
        /// The number of times this discount has been used
        /// </summary>
        [JsonProperty("times_used")]
        public int TimesUsed { get; set; }

        /// <summary>
        /// The date and time when the discount becomes valid
        /// </summary>
        [JsonProperty("valid_from")]
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// The date and time when the discount expires
        /// </summary>
        [JsonProperty("valid_until")]
        public DateTime? ValidUntil { get; set; }

        /// <summary>
        /// The status of the discount (active, expired, depleted)
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The restrictions that apply to this discount
        /// </summary>
        [JsonProperty("restrictions")]
        public DiscountRestrictions Restrictions { get; set; }

        /// <summary>
        /// Custom data associated with the discount
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// When the discount was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the discount was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Represents restrictions that apply to a discount
    /// </summary>
    public class DiscountRestrictions
    {
        /// <summary>
        /// The minimum charge amount required to use the discount
        /// </summary>
        [JsonProperty("minimum_charge_amount")]
        public decimal? MinimumChargeAmount { get; set; }

        /// <summary>
        /// The currency code for the minimum charge amount
        /// </summary>
        [JsonProperty("minimum_charge_currency")]
        public string MinimumChargeCurrency { get; set; }

        /// <summary>
        /// The products this discount can be applied to
        /// </summary>
        [JsonProperty("product_ids")]
        public string[] ProductIds { get; set; }

        /// <summary>
        /// The prices this discount can be applied to
        /// </summary>
        [JsonProperty("price_ids")]
        public string[] PriceIds { get; set; }

        /// <summary>
        /// The customers who can use this discount
        /// </summary>
        [JsonProperty("customer_ids")]
        public string[] CustomerIds { get; set; }

        /// <summary>
        /// Whether the discount can be combined with other discounts
        /// </summary>
        [JsonProperty("allows_stacking")]
        public bool AllowsStacking { get; set; }
    }
}