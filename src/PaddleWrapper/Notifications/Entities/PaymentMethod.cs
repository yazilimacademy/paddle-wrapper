using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities;

public class PaymentMethod : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("customer_id")]
    public string CustomerId { get; }

    [JsonPropertyName("address_id")]
    public string AddressId { get; }

    [JsonPropertyName("type")]
    public SavedPaymentMethodType Type { get; }

    [JsonPropertyName("origin")]
    public SavedPaymentMethodOrigin Origin { get; }

    [JsonPropertyName("saved_at")]
    public DateTime SavedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; }

    private PaymentMethod(
        string id,
        string customerId,
        string addressId,
        SavedPaymentMethodType type,
        SavedPaymentMethodOrigin origin,
        DateTime savedAt,
        DateTime updatedAt)
    {
        Id = id;
        CustomerId = customerId;
        AddressId = addressId;
        Type = type;
        Origin = origin;
        SavedAt = savedAt;
        UpdatedAt = updatedAt;
    }

    public static IEntity FromJson(JsonElement json)
    {
        return new PaymentMethod(
            id: json.GetProperty("id").GetString()!,
            customerId: json.GetProperty("customer_id").GetString()!,
            addressId: json.GetProperty("address_id").GetString()!,
            type: JsonSerializer.Deserialize<SavedPaymentMethodType>(json.GetProperty("type").GetRawText())!,
            origin: JsonSerializer.Deserialize<SavedPaymentMethodOrigin>(json.GetProperty("origin").GetRawText())!,
            savedAt: DateTime.Parse(json.GetProperty("saved_at").GetString()!),
            updatedAt: DateTime.Parse(json.GetProperty("updated_at").GetString()!)
        );
    }
}