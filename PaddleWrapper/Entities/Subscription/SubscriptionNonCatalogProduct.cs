using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionNonCatalogProduct
    {
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

        private SubscriptionNonCatalogProduct(
            string name,
            string? description,
            CatalogType? type,
            TaxCategory taxCategory,
            string? imageUrl,
            CustomData? customData)
        {
            Name = name;
            Description = description;
            Type = type;
            TaxCategory = taxCategory;
            ImageUrl = imageUrl;
            CustomData = customData;
        }

        public static SubscriptionNonCatalogProduct From(Dictionary<string, object> data)
        {
            return new SubscriptionNonCatalogProduct(
                name: (string)data["name"],
                description: data.ContainsKey("description") ? (string?)data["description"] : null,
                type: data.ContainsKey("type") ? System.Enum.Parse<CatalogType>((string)data["type"], true) : null,
                taxCategory: System.Enum.Parse<TaxCategory>((string)data["tax_category"], true),
                imageUrl: data.ContainsKey("image_url") ? (string?)data["image_url"] : null,
                customData: data.ContainsKey("custom_data") ? CustomData.From((Dictionary<string, object>)data["custom_data"]) : null
            );
        }
    }
} 