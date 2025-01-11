using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Transaction;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class Card
{
    [JsonPropertyName("type")]
    public TransactionCardType Type { get; set; }

    [JsonPropertyName("last4")]
    public string Last4 { get; set; }

    [JsonPropertyName("expiry_month")]
    public int ExpiryMonth { get; set; }

    [JsonPropertyName("expiry_year")]
    public int ExpiryYear { get; set; }

    [JsonPropertyName("cardholder_name")]
    public string? CardholderName { get; set; }

    public static Card FromJson(JsonElement data)
    {
        return new Card
        {
            Type = JsonSerializer.Deserialize<TransactionCardType>(data.GetProperty("type").GetRawText()),
            Last4 = data.GetProperty("last4").GetString()!,
            ExpiryMonth = data.GetProperty("expiry_month").GetInt32(),
            ExpiryYear = data.GetProperty("expiry_year").GetInt32(),
            CardholderName = data.TryGetProperty("cardholder_name", out var name) ? name.GetString() : null
        };
    }
} 