using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Products.Operations
{
    public class UpdateProduct
    {
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CatalogType? Type { get; set; }

        [JsonPropertyName("tax_category")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxCategory? TaxCategory { get; set; }

        [JsonPropertyName("image_url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("custom_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomData? CustomData { get; set; }

        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Status? Status { get; set; }
    }
}