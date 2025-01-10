using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Products
{
    /// <summary>
    /// Represents a product in the Paddle system
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The unique identifier for the product
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The tax category for the product
        /// </summary>
        [JsonProperty("tax_category")]
        public string TaxCategory { get; set; }

        /// <summary>
        /// The type of the product
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The description of the product
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The URL of the product image
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Custom data associated with the product
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// The status of the product
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Import metadata for the product
        /// </summary>
        [JsonProperty("import_meta")]
        public object ImportMeta { get; set; }

        /// <summary>
        /// When the product was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the product was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}