using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities;

public class PaymentMethodTransaction
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("customer_id")]
    public string CustomerId { get; set; }

    [JsonPropertyName("business_id")]
    public string BusinessId { get; set; }

    [JsonPropertyName("subscription_id")]
    public string SubscriptionId { get; set; }

    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; set; }

    [JsonPropertyName("payment_method")]
    public PaymentMethod PaymentMethod { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public static PaymentMethodTransaction FromJson(JsonElement element)
    {
        return new PaymentMethodTransaction
        {
            Id = element.GetProperty("id").GetString() ?? string.Empty,
            Status = element.GetProperty("status").GetString() ?? string.Empty,
            CustomerId = element.GetProperty("customer_id").GetString() ?? string.Empty,
            BusinessId = element.GetProperty("business_id").GetString() ?? string.Empty,
            SubscriptionId = element.GetProperty("subscription_id").GetString() ?? string.Empty,
            Amount = element.GetProperty("amount").GetString() ?? string.Empty,
            CurrencyCode = element.GetProperty("currency_code").GetString() ?? string.Empty,
            PaymentMethod = PaymentMethod.FromJson(element.GetProperty("payment_method")),
            CreatedAt = element.GetProperty("created_at").GetDateTime(),
            UpdatedAt = element.GetProperty("updated_at").GetDateTime()
        };
    }
}