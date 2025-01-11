using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Price;

namespace PaddleWrapper.Notifications.Entities.Transaction;

public class TransactionItem
{
    [JsonPropertyName("price_id")]
    public string? PriceId { get; set; }

    [JsonPropertyName("price")]
    public Price Price { get; set; }

    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }

    [JsonPropertyName("proration")]
    public TransactionProration? Proration { get; set; }

    public static TransactionItem FromJson(JsonElement data)
    {
        return new TransactionItem
        {
            PriceId = data.TryGetProperty("price_id", out var priceId) ? priceId.GetString() : null,
            Price = Price.FromJson(data.GetProperty("price")),
            Quantity = data.TryGetProperty("quantity", out var quantity) ? quantity.GetInt32() : null,
            Proration = data.TryGetProperty("proration", out var proration) ? TransactionProration.FromJson(proration) : null
        };
    }
} 