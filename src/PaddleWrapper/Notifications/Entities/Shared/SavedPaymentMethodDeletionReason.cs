using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SavedPaymentMethodDeletionReason
{
    [JsonPropertyName("replaced_by_newer_version")]
    ReplacedByNewerVersion,
    [JsonPropertyName("api")]
    Api
}