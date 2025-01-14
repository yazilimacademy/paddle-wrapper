using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations.Price
{
    public class TransactionNonCatalogProduct
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("tax_category")]
        public string TaxCategory { get; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; }

        [JsonPropertyName("image_url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ImageUrl { get; }

        [JsonPropertyName("custom_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomData CustomData { get; }

        public TransactionNonCatalogProduct(
            string name,
            TaxCategory taxCategory,
            string description = null,
            string imageUrl = null,
            CustomData customData = null)
        {
            Name = name;
            TaxCategory = taxCategory.ToString();
            Description = description;
            ImageUrl = imageUrl;
            CustomData = customData;
        }
    }
}