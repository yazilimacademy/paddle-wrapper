using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class BillingDetails
{
    [JsonPropertyName("enable_checkout")]
    public bool EnableCheckout { get; set; }

    [JsonPropertyName("payment_terms")]
    public TimePeriod PaymentTerms { get; set; }

    [JsonPropertyName("purchase_order_number")]
    public string? PurchaseOrderNumber { get; set; }

    [JsonPropertyName("additional_information")]
    public string? AdditionalInformation { get; set; }

    public static BillingDetails FromJson(JsonElement data)
    {
        return new BillingDetails
        {
            EnableCheckout = data.GetProperty("enable_checkout").GetBoolean(),
            PaymentTerms = TimePeriod.FromJson(data.GetProperty("payment_terms")),
            PurchaseOrderNumber = data.TryGetProperty("purchase_order_number", out JsonElement pon) ? pon.GetString() : null,
            AdditionalInformation = data.TryGetProperty("additional_information", out JsonElement ai) ? ai.GetString() : null
        };
    }
}