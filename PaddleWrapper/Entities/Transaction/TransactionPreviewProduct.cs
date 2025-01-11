using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionPreviewProduct
    {
        [JsonPropertyName("id")]
        public string? Id { get; }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("description")]
        public string? Description { get; }

        [JsonPropertyName("type")]
        public CatalogType? Type { get; }

        [JsonPropertyName("tax_category")]
        public TaxCategory TaxCategory { get; }

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        [JsonPropertyName("status")]
        public Status Status { get; }

        [JsonPropertyName("import_meta")]
        public ImportMeta? ImportMeta { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        private TransactionPreviewProduct(
            string? id,
            string name,
            string? description,
            CatalogType? type,
            TaxCategory taxCategory,
            string? imageUrl,
            CustomData? customData,
            Status status,
            ImportMeta? importMeta,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            TaxCategory = taxCategory;
            ImageUrl = imageUrl;
            CustomData = customData;
            Status = status;
            ImportMeta = importMeta;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static TransactionPreviewProduct From(Dictionary<string, object> data)
        {
            return new TransactionPreviewProduct(
                id: data.ContainsKey("id") ? (string?)data["id"] : null,
                name: (string)data["name"],
                description: data.ContainsKey("description") ? (string?)data["description"] : null,
                type: data.ContainsKey("type") ? System.Enum.Parse<CatalogType>((string)data["type"], true) : null,
                taxCategory: System.Enum.Parse<TaxCategory>((string)data["tax_category"], true),
                imageUrl: data.ContainsKey("image_url") ? (string?)data["image_url"] : null,
                customData: data.ContainsKey("custom_data") ? CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                status: System.Enum.Parse<Status>((string)data["status"], true),
                importMeta: data.ContainsKey("import_meta") ? ImportMeta.From((Dictionary<string, object>)data["import_meta"]) : null,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"])
            );
        }
    }
}