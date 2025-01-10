using Newtonsoft.Json;

namespace PaddleWrapper.Core.Models.Subscription
{
    public class Subscription
    {
        [JsonProperty("subscription_id")]
        public int SubscriptionId { get; set; }

        [JsonProperty("plan_id")]
        public int PlanId { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("user_email")]
        public string UserEmail { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("next_payment")]
        public SubscriptionPayment NextPayment { get; set; }

        [JsonProperty("last_payment")]
        public SubscriptionPayment LastPayment { get; set; }

        [JsonProperty("pause_date")]
        public DateTime? PauseDate { get; set; }

        [JsonProperty("cancellation_effective_date")]
        public DateTime? CancellationEffectiveDate { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class SubscriptionPayment
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}