using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Product;
using PaddleWrapper.Notifications.Entities.Shared;

namespace PaddleWrapper.Notifications.Entities.Transaction;

public class TransactionLineItem
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("price_id")]
    public string PriceId { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("proration")]
    public TransactionProration? Proration { get; set; }

    [JsonPropertyName("tax_rate")]
    public string TaxRate { get; set; }

    [JsonPropertyName("unit_totals")]
    public UnitTotals UnitTotals { get; set; }

    [JsonPropertyName("totals")]
    public Totals Totals { get; set; }

    [JsonPropertyName("product")]
    public Product Product { get; set; }

    public static TransactionLineItem FromJson(JsonElement data)
    {
        return new TransactionLineItem
        {
            Id = data.GetProperty("id").GetString()!,
            PriceId = data.GetProperty("price_id").GetString()!,
            Quantity = data.GetProperty("quantity").GetInt32(),
            Proration = data.TryGetProperty("proration", out var proration) ? TransactionProration.FromJson(proration) : null,
            TaxRate = data.GetProperty("tax_rate").GetString()!,
            UnitTotals = UnitTotals.FromJson(data.GetProperty("unit_totals")),
            Totals = Totals.FromJson(data.GetProperty("totals")),
            Product = Product.FromJson(data.GetProperty("product"))
        };
    }
} 