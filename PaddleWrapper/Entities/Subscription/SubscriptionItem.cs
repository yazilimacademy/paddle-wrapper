using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionItem
    {
        [JsonPropertyName("status")]
        public SubscriptionItemStatus Status { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        [JsonPropertyName("recurring")]
        public bool Recurring { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        [JsonPropertyName("previously_billed_at")]
        public DateTime? PreviouslyBilledAt { get; }

        [JsonPropertyName("next_billed_at")]
        public DateTime? NextBilledAt { get; }

        [JsonPropertyName("trial_dates")]
        public SubscriptionTimePeriod? TrialDates { get; }

        [JsonPropertyName("price")]
        public Price.Price Price { get; }

        [JsonPropertyName("product")]
        public Product.Product Product { get; }

        private SubscriptionItem(
            SubscriptionItemStatus status,
            int quantity,
            bool recurring,
            DateTime createdAt,
            DateTime updatedAt,
            DateTime? previouslyBilledAt,
            DateTime? nextBilledAt,
            SubscriptionTimePeriod? trialDates,
            Price.Price price,
            Product.Product product)
        {
            Status = status;
            Quantity = quantity;
            Recurring = recurring;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            PreviouslyBilledAt = previouslyBilledAt;
            NextBilledAt = nextBilledAt;
            TrialDates = trialDates;
            Price = price;
            Product = product;
        }

        public static SubscriptionItem From(Dictionary<string, object> data)
        {
            return new SubscriptionItem(
                status: System.Enum.Parse<SubscriptionItemStatus>((string)data["status"], true),
                quantity: (int)data["quantity"],
                recurring: (bool)data["recurring"],
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"]),
                previouslyBilledAt: data.ContainsKey("previously_billed_at") ? DateTime.Parse((string)data["previously_billed_at"]) : null,
                nextBilledAt: data.ContainsKey("next_billed_at") ? DateTime.Parse((string)data["next_billed_at"]) : null,
                trialDates: data.ContainsKey("trial_dates") ? SubscriptionTimePeriod.From((Dictionary<string, object>)data["trial_dates"]) : null,
                price: Price.Price.From((Dictionary<string, object>)data["price"]),
                product: Product.Product.From((Dictionary<string, object>)data["product"])
            );
        }
    }
}