using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Shared;

namespace PaddleWrapper.Notifications.Entities.Subscription;

public class SubscriptionCredit
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("currency_code")]
    public CurrencyCode CurrencyCode { get; set; }

    public static SubscriptionCredit FromJson(JsonElement data)
    {
        return new SubscriptionCredit
        {
            Amount = data.GetProperty("amount").GetString()!,
            CurrencyCode = JsonSerializer.Deserialize<CurrencyCode>(data.GetProperty("currency_code").GetRawText())
        };
    }
} 