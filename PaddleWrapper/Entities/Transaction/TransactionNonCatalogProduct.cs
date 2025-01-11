using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionNonCatalogProduct
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("description")]
        public string? Description { get; }

        [JsonPropertyName("tax_category")]
        public TaxCategory TaxCategory { get; }

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        private TransactionNonCatalogProduct(
            string name,
            string? description,
            TaxCategory taxCategory,
            string? imageUrl,
            CustomData? customData)
        {
            Name = name;
            Description = description;
            TaxCategory = taxCategory;
            ImageUrl = imageUrl;
            CustomData = customData;
        }

        public static TransactionNonCatalogProduct From(Dictionary<string, object> data)
        {
            return new TransactionNonCatalogProduct(
                name: (string)data["name"],
                description: data.ContainsKey("description") ? (string?)data["description"] : null,
                taxCategory: System.Enum.Parse<TaxCategory>((string)data["tax_category"], true),
                imageUrl: data.ContainsKey("image_url") ? (string?)data["image_url"] : null,
                customData: data.ContainsKey("custom_data") ? CustomData.From((Dictionary<string, object>)data["custom_data"]) : null
            );
        }
    }
}