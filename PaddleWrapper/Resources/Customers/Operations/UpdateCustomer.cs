using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Customers.Operations
{
    public class UpdateCustomer
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; set; }

        [JsonPropertyName("locale")]
        public string? Locale { get; set; }

        [JsonPropertyName("status")]
        public Status? Status { get; set; }

        public UpdateCustomer(
            string? email = null,
            string? name = null,
            CustomData? customData = null,
            string? locale = null,
            Status? status = null)
        {
            Email = email;
            Name = name;
            CustomData = customData;
            Locale = locale;
            Status = status;
        }
    }
}