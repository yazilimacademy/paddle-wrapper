using System.Text.Json.Serialization;

namespace PaddleWrapper.Models
{
    public class Customer
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("customer_number")]
        public string CustomerNumber { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("custom_data")]
        public object CustomData { get; set; }

        [JsonPropertyName("marketing_consent")]
        public bool MarketingConsent { get; set; }
    }
}