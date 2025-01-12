using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Subscriptions;

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