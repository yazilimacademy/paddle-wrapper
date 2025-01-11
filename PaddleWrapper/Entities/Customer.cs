using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

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

        public static Customer From(Dictionary<string, object> data)
        {
            return new Customer(
                id: (string)data["id"],
                name: data.ContainsKey("name") ? (string?)data["name"] : null,
                email: (string)data["email"],
                marketingConsent: (bool)data["marketing_consent"],
                status: System.Enum.Parse<Status>((string)data["status"], true),
                customData: data.ContainsKey("custom_data") ? 
                    CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                locale: (string)data["locale"],
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"]),
                importMeta: data.ContainsKey("import_meta") ? 
                    ImportMeta.From((Dictionary<string, object>)data["import_meta"]) : null
            );
        }
    }
} 