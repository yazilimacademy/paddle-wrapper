using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Shared;

namespace PaddleWrapper.Notifications.Entities.Subscription;

public class SubscriptionCharge
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode CurrencyCode { get; set; }

    public static SubscriptionCharge FromJson(JsonElement data)
    {
        return new SubscriptionCharge
        {
            Amount = data.GetProperty("amount").GetString()!,
            CurrencyCode = JsonSerializer.Deserialize<CurrencyCode>(data.GetProperty("currency_code").GetRawText())
        };
    }
} 