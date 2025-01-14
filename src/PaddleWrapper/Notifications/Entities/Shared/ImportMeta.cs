using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class ImportMeta
{
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; }

    [JsonPropertyName("imported_from")]
    public string? ImportedFrom { get; }

    private ImportMeta(string? externalId, string? importedFrom)
    {
        ExternalId = externalId;
        ImportedFrom = importedFrom;
    }

    public static ImportMeta? FromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        return new ImportMeta(
            element.TryGetProperty("external_id", out JsonElement externalId) ? externalId.GetString() : null,
            element.TryGetProperty("imported_from", out JsonElement importedFrom) ? importedFrom.GetString() : null
        );
    }
}