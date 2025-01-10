using Newtonsoft.Json;

namespace PaddleWrapper.Core.Models.Payment
{
    public class PaymentRequest
    {
        [JsonProperty("product_id")]
        public int? ProductId { get; set; }

        [JsonProperty("subscription_id")]
        public int? SubscriptionId { get; set; }

        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("billing_period")]
        public int? BillingPeriod { get; set; }

        [JsonProperty("billing_frequency")]
        public string BillingFrequency { get; set; }

        [JsonProperty("trial_days")]
        public int? TrialDays { get; set; }

        [JsonProperty("coupon")]
        public string Coupon { get; set; }

        [JsonProperty("passthrough")]
        public string Passthrough { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
    }
} 