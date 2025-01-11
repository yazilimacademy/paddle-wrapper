using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Resources.Customers.Operations
{
    public class CreateCustomer
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; set; }

        [JsonPropertyName("locale")]
        public string? Locale { get; set; }

        public CreateCustomer(
            string email,
            string? name = null,
            CustomData? customData = null,
            string? locale = null)
        {
            Email = email;
            Name = name;
            CustomData = customData;
            Locale = locale;
        }
    }
} 