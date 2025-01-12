using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Transactions;

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
            PriceId = data.TryGetProperty("price_id", out JsonElement priceId) ? priceId.GetString() : null,
            Price = Price.FromJson(data.GetProperty("price")),
            Quantity = data.TryGetProperty("quantity", out JsonElement quantity) ? quantity.GetInt32() : null,
            Proration = data.TryGetProperty("proration", out JsonElement proration) ? TransactionProration.FromJson(proration) : null
        };
    }
}