using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Transactions;

public class TransactionProration
{
    [JsonPropertyName("rate")]
    public string Rate { get; set; }

    [JsonPropertyName("billing_period")]
    public TransactionTimePeriod? BillingPeriod { get; set; }

    public static TransactionProration FromJson(JsonElement data)
    {
        return new TransactionProration
        {
            Rate = data.GetProperty("rate").GetString()!,
            BillingPeriod = data.TryGetProperty("billing_period", out var billingPeriod) 
                ? TransactionTimePeriod.FromJson(billingPeriod) 
                : null
        };
    }
} 