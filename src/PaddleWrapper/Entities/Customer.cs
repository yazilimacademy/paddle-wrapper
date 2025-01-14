using PaddleWrapper.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;
using CustomData = PaddleWrapper.Notifications.Entities.Shared.CustomData;
using ImportMeta = PaddleWrapper.Notifications.Entities.Shared.ImportMeta;

namespace PaddleWrapper.Entities
{
    public class Customer
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("name")]
        public string? Name { get; }

        [JsonPropertyName("email")]
        public string Email { get; }

        [JsonPropertyName("marketing_consent")]
        public bool MarketingConsent { get; }

        [JsonPropertyName("status")]
        public Status Status { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        [JsonPropertyName("locale")]
        public string Locale { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        [JsonPropertyName("import_meta")]
        public ImportMeta? ImportMeta { get; }

        private Customer(
            string id,
            string? name,
            string email,
            bool marketingConsent,
            Status status,
            CustomData? customData,
            string locale,
            DateTime createdAt,
            DateTime updatedAt,
            ImportMeta? importMeta)
        {
            Id = id;
            Name = name;
            Email = email;
            MarketingConsent = marketingConsent;
            Status = status;
            CustomData = customData;
            Locale = locale;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ImportMeta = importMeta;
        }

        public static Customer FromJson(JsonElement json)
        {
            return new Customer(
                id: json.GetProperty("id").GetString()!,
                name: json.GetProperty("name").ValueKind == JsonValueKind.Null ? null : json.GetProperty("name").GetString(),
                email: json.GetProperty("email").GetString()!,
                marketingConsent: json.GetProperty("marketing_consent").GetBoolean(),
                status: Enum.Parse<Status>(json.GetProperty("status").GetString()!, true),
                customData: json.GetProperty("custom_data").ValueKind == JsonValueKind.Null ? null :
                    CustomData.FromJson(json.GetProperty("custom_data")),
                locale: json.GetProperty("locale").GetString()!,
                createdAt: DateTime.Parse(json.GetProperty("created_at").GetString()!),
                updatedAt: DateTime.Parse(json.GetProperty("updated_at").GetString()!),
                importMeta: json.GetProperty("import_meta").ValueKind == JsonValueKind.Null ? null :
                    ImportMeta.FromJson(json.GetProperty("import_meta"))
            );
        }

        public static Customer From(Dictionary<string, object> data)
        {
            JsonElement json = JsonSerializer.SerializeToElement(data);
            return FromJson(json);
        }
    }
}