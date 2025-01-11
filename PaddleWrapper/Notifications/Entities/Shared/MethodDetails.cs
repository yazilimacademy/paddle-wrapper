using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class MethodDetails
{
    [JsonPropertyName("type")]
    public PaymentMethodType Type { get; }

    [JsonPropertyName("card")]
    public Card? Card { get; }

    private MethodDetails(PaymentMethodType type, Card? card)
    {
        Type = type;
        Card = card;
    }

    public static MethodDetails FromJson(JsonElement element)
    {
        return new MethodDetails(
            JsonSerializer.Deserialize<PaymentMethodType>(element.GetProperty("type").GetRawText()),
            element.TryGetProperty("card", out var card) ? Card.FromJson(card) : null
        );
    }
} 