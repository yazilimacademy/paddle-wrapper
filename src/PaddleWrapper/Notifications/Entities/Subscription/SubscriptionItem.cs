using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscriptions;

public class SubscriptionItem
{
    [JsonPropertyName("status")]
    public SubscriptionItemStatus Status { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("recurring")]
    public bool Recurring { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("previously_billed_at")]
    public DateTime? PreviouslyBilledAt { get; set; }

    [JsonPropertyName("next_billed_at")]
    public DateTime? NextBilledAt { get; set; }

    [JsonPropertyName("trial_dates")]
    public SubscriptionTimePeriod? TrialDates { get; set; }

    [JsonPropertyName("price")]
    public SubscriptionPrice Price { get; set; }

    [JsonPropertyName("product")]
    public Product? Product { get; set; }

    public static SubscriptionItem FromJson(JsonElement data)
    {
        return new SubscriptionItem
        {
            Status = JsonSerializer.Deserialize<SubscriptionItemStatus>(data.GetProperty("status").GetRawText()),
            Quantity = data.GetProperty("quantity").GetInt32(),
            Recurring = data.GetProperty("recurring").GetBoolean(),
            CreatedAt = DateTime.Parse(data.GetProperty("created_at").GetString()!),
            UpdatedAt = DateTime.Parse(data.GetProperty("updated_at").GetString()!),
            PreviouslyBilledAt = data.TryGetProperty("previously_billed_at", out JsonElement previouslyBilledAt) && !previouslyBilledAt.ValueKind.Equals(JsonValueKind.Null)
                ? DateTime.Parse(previouslyBilledAt.GetString()!)
                : null,
            NextBilledAt = data.TryGetProperty("next_billed_at", out JsonElement nextBilledAt) && !nextBilledAt.ValueKind.Equals(JsonValueKind.Null)
                ? DateTime.Parse(nextBilledAt.GetString()!)
                : null,
            TrialDates = data.TryGetProperty("trial_dates", out JsonElement trialDates)
                ? SubscriptionTimePeriod.FromJson(trialDates)
                : null,
            Price = SubscriptionPrice.FromJson(data.GetProperty("price")),
            Product = (Product)(data.TryGetProperty("product", out JsonElement product)
                ? Product.FromJson(product)
                : null)
        };
    }
}