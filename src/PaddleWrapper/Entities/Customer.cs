using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class Customer : Entity
    {
        public string Name { get; }
        public string Email { get; }
        public string Locale { get; }
        public Status Status { get; }
        public bool MarketingConsent { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public CustomData CustomData { get; }
        public ImportMeta ImportMeta { get; }

        public Customer(
            string id,
            string name,
            string email,
            string locale,
            Status status,
            bool marketingConsent,
            DateTime createdAt,
            DateTime updatedAt,
            CustomData customData = null,
            ImportMeta importMeta = null)
        {
            Id = id;
            Name = name;
            Email = email;
            Locale = locale;
            Status = status;
            MarketingConsent = marketingConsent;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CustomData = customData;
            ImportMeta = importMeta;
        }

        public static Customer FromDict(JsonElement data)
        {
            return new Customer(
                id: data.GetProperty("id").GetString(),
                name: data.GetProperty("name").GetString(),
                email: data.GetProperty("email").GetString(),
                locale: data.GetProperty("locale").GetString(),
                status: Enum.Parse<Status>(data.GetProperty("status").GetString()),
                marketingConsent: data.GetProperty("marketing_consent").GetBoolean(),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString()),
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                importMeta: data.TryGetProperty("import_meta", out var importMeta) ? ImportMeta.FromDict(importMeta) : null
            );
        }
    }
} 