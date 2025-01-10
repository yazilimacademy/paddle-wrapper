using System;
using Newtonsoft.Json;

namespace PaddleWrapper.Core.Models.Product
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("base_price")]
        public decimal BasePrice { get; set; }

        [JsonProperty("sale_price")]
        public decimal? SalePrice { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
} 