using PaddleWrapper.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class Product
    {
        [JsonPropertyName("id")]
        public string Id { get; }

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

        [JsonPropertyName("prices")]
        public IReadOnlyList<Price> Prices { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        private Product(
            string id,
            string name,
            string? description,
            CatalogType? type,
            TaxCategory taxCategory,
            string? imageUrl,
            CustomData? customData,
            Status status,
            ImportMeta? importMeta,
            IReadOnlyList<Price> prices,
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
            Prices = prices;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Product FromJson(JsonElement json)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()));
        }

        public static Product From(Dictionary<string, object> data)
        {
            List<Price> prices = new();
            if (data.ContainsKey("prices"))
            {
                object[] pricesData = (object[])data["prices"];
                foreach (object price in pricesData)
                {
                    prices.Add(Price.From((Dictionary<string, object>)price));
                }
            }

            return new Product(
                id: (string)data["id"],
                name: (string)data["name"],
                description: data.ContainsKey("description") ? (string?)data["description"] : null,
                type: data.ContainsKey("type") && data["type"] != null ?
                    Enum.Parse<CatalogType>((string)data["type"], true) : null,
                taxCategory: Enum.Parse<TaxCategory>((string)data["tax_category"], true),
                imageUrl: data.ContainsKey("image_url") ? (string?)data["image_url"] : null,
                customData: data.ContainsKey("custom_data") ?
                    CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                status: Enum.Parse<Status>((string)data["status"], true),
                importMeta: data.ContainsKey("import_meta") ?
                    ImportMeta.From((Dictionary<string, object>)data["import_meta"]) : null,
                prices: prices,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"])
            );
        }
    }
}