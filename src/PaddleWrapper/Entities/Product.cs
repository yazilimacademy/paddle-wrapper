using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class Product : Entity
    {
        public string Name { get; }
        public TaxCategory TaxCategory { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public CustomData CustomData { get; }
        public Status Status { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public ImportMeta ImportMeta { get; }

        public Product(
            string id,
            string name,
            TaxCategory taxCategory,
            string description,
            string imageUrl,
            CustomData customData,
            Status status,
            DateTime createdAt,
            DateTime updatedAt,
            ImportMeta importMeta)
        {
            Id = id;
            Name = name;
            TaxCategory = taxCategory;
            Description = description;
            ImageUrl = imageUrl;
            CustomData = customData;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ImportMeta = importMeta;
        }

        public static Product FromDict(JsonElement data)
        {
            return new Product(
                id: data.GetProperty("id").GetString(),
                name: data.GetProperty("name").GetString(),
                taxCategory: Enum.Parse<TaxCategory>(data.GetProperty("tax_category").GetString()),
                description: data.GetProperty("description").GetString(),
                imageUrl: data.GetProperty("image_url").GetString(),
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                status: Enum.Parse<Status>(data.GetProperty("status").GetString()),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString()),
                importMeta: data.TryGetProperty("import_meta", out var importMeta) ? ImportMeta.FromDict(importMeta) : null
            );
        }
    }
} 