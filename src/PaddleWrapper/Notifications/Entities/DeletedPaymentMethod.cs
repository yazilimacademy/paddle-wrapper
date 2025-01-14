using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities;

public class DeletedPaymentMethod : IEntity
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

    [JsonPropertyName("deletion_reason")]
    public SavedPaymentMethodDeletionReason DeletionReason { get; }

    private DeletedPaymentMethod(string id, string customerId, string addressId, SavedPaymentMethodType type,
        SavedPaymentMethodOrigin origin, DateTime savedAt, DateTime updatedAt, SavedPaymentMethodDeletionReason deletionReason)
    {
        Id = id;
        CustomerId = customerId;
        AddressId = addressId;
        Type = type;
        Origin = origin;
        SavedAt = savedAt;
        UpdatedAt = updatedAt;
        DeletionReason = deletionReason;
    }

    public static DeletedPaymentMethod FromJson(JsonElement json)
    {
        string id = json.GetProperty("id").GetString()!;
        string customerId = json.GetProperty("customer_id").GetString()!;
        string addressId = json.GetProperty("address_id").GetString()!;
        SavedPaymentMethodType type = JsonSerializer.Deserialize<SavedPaymentMethodType>(json.GetProperty("type").GetRawText())!;
        SavedPaymentMethodOrigin origin = JsonSerializer.Deserialize<SavedPaymentMethodOrigin>(json.GetProperty("origin").GetRawText())!;
        DateTime? savedAt = DateTime.Parse(json.GetProperty("saved_at").GetString()!);
        DateTime? updatedAt = DateTime.Parse(json.GetProperty("updated_at").GetString()!);
        SavedPaymentMethodDeletionReason deletionReason = JsonSerializer.Deserialize<SavedPaymentMethodDeletionReason>(json.GetProperty("deletion_reason").GetRawText())!;

        return new DeletedPaymentMethod(id, customerId, addressId, type, origin, savedAt, updatedAt, deletionReason);
    }
}