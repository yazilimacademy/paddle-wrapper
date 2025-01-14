using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class ImportMeta
    {
        [JsonPropertyName("external_id")]
        public string? ExternalId { get; }

        [JsonPropertyName("imported_from")]
        public string ImportedFrom { get; }

        [JsonConstructor]
        public ImportMeta(string? externalId, string importedFrom)
        {
            ExternalId = externalId;
            ImportedFrom = importedFrom;
        }

        public static ImportMeta? FromJson(JsonElement json)
        {
            if (json.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string? externalId = null;
            if (json.TryGetProperty("external_id", out JsonElement externalIdElement) &&
                externalIdElement.ValueKind != JsonValueKind.Null)
            {
                externalId = externalIdElement.GetString();
            }

            if (!json.TryGetProperty("imported_from", out JsonElement importedFromElement) ||
                importedFromElement.ValueKind == JsonValueKind.Null)
            {
                throw new JsonException("Required property 'imported_from' is missing or null");
            }

            string importedFrom = importedFromElement.GetString()!;
            return new ImportMeta(externalId, importedFrom);
        }

        public static ImportMeta From(Dictionary<string, object> data)
        {
            return new ImportMeta(
                externalId: data.ContainsKey("external_id") ? data["external_id"]?.ToString() : null,
                importedFrom: data["imported_from"].ToString()
            );
        }
    }
}