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

        public static ImportMeta From(Dictionary<string, object> data)
        {
            return new ImportMeta(
                externalId: data.ContainsKey("external_id") ? data["external_id"]?.ToString() : null,
                importedFrom: data["imported_from"].ToString()
            );
        }
    }
}