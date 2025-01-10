using System.Text.Json.Serialization;

namespace PaddleWrapper.Models
{
    public class Subscription
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("address_id")]
        public string AddressId { get; set; }

        [JsonPropertyName("business_id")]
        public string BusinessId { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonPropertyName("first_billed_at")]
        public DateTime? FirstBilledAt { get; set; }

        [JsonPropertyName("next_billed_at")]
        public DateTime? NextBilledAt { get; set; }

        [JsonPropertyName("paused_at")]
        public DateTime? PausedAt { get; set; }

        [JsonPropertyName("canceled_at")]
        public DateTime? CanceledAt { get; set; }

        [JsonPropertyName("billing_cycle")]
        public BillingCycle BillingCycle { get; set; }

        [JsonPropertyName("current_billing_period")]
        public BillingPeriod CurrentBillingPeriod { get; set; }

        [JsonPropertyName("billing_details")]
        public BillingDetails BillingDetails { get; set; }

        [JsonPropertyName("items")]
        public SubscriptionItem[] Items { get; set; }

        [JsonPropertyName("scheduled_change")]
        public ScheduledChange ScheduledChange { get; set; }

        [JsonPropertyName("custom_data")]
        public object CustomData { get; set; }
    }

    public class BillingCycle
    {
        [JsonPropertyName("interval")]
        public string Interval { get; set; }

        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }
    }

    public class BillingPeriod
    {
        [JsonPropertyName("starts_at")]
        public DateTime StartsAt { get; set; }

        [JsonPropertyName("ends_at")]
        public DateTime EndsAt { get; set; }
    }

    public class SubscriptionItem
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("recurring")]
        public bool Recurring { get; set; }
    }

    public class ScheduledChange
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("effective_at")]
        public DateTime EffectiveAt { get; set; }

        [JsonPropertyName("resume_at")]
        public DateTime? ResumeAt { get; set; }
    }
}