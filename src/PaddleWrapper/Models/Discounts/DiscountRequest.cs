using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Discounts
{
    /// <summary>
    /// Represents a request to create or update a discount
    /// </summary>
    public class DiscountRequest
    {
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
        /// The restrictions that apply to this discount
        /// </summary>
        [JsonProperty("restrictions")]
        public DiscountRestrictions Restrictions { get; set; }

        /// <summary>
        /// Custom data associated with the discount
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }
    }
}