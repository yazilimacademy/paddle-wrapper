using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Products.Operations
{
    public class CreateProduct
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("tax_category")]
        public TaxCategory TaxCategory { get; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CatalogType? Type { get; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; }

        [JsonPropertyName("image_url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageUrl { get; }

        [JsonPropertyName("custom_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomData? CustomData { get; }

        public CreateProduct(
            string name,
            TaxCategory taxCategory,
            CatalogType? type = null,
            string? description = null,
            string? imageUrl = null,
            CustomData? customData = null)
        {
            Name = name;
            TaxCategory = taxCategory;
            Type = type;
            Description = description;
            ImageUrl = imageUrl;
            CustomData = customData;
        }
    }
}