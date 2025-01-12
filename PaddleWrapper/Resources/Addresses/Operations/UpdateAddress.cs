using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Addresses.Operations
{
    public class UpdateAddress
    {
        [JsonPropertyName("country_code")]
        public CountryCode? CountryCode { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("first_line")]
        public string? FirstLine { get; set; }

        [JsonPropertyName("second_line")]
        public string? SecondLine { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; set; }

        [JsonPropertyName("status")]
        public Status? Status { get; set; }
    }
}