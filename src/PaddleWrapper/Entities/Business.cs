using PaddleWrapper.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class Business
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; }

        [JsonPropertyName("company_number")]
        public string? CompanyNumber { get; }

        [JsonPropertyName("tax_identifier")]
        public string? TaxIdentifier { get; }

        [JsonPropertyName("status")]
        public Status Status { get; }

        [JsonPropertyName("contacts")]
        public IReadOnlyList<Contacts> Contacts { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        [JsonPropertyName("import_meta")]
        public ImportMeta? ImportMeta { get; }

        private Business(
            string id,
            string name,
            string customerId,
            string? companyNumber,
            string? taxIdentifier,
            Status status,
            IReadOnlyList<Contacts> contacts,
            DateTime createdAt,
            DateTime updatedAt,
            CustomData? customData,
            ImportMeta? importMeta)
        {
            Id = id;
            Name = name;
            CustomerId = customerId;
            CompanyNumber = companyNumber;
            TaxIdentifier = taxIdentifier;
            Status = status;
            Contacts = contacts;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CustomData = customData;
            ImportMeta = importMeta;
        }

        public static Business FromJson(JsonElement json)
        {
            List<Contacts> contacts = new();
            if (json.TryGetProperty("contacts", out JsonElement contactsElement) &&
                contactsElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement contact in contactsElement.EnumerateArray())
                {
                    contacts.Add(Shared.Contacts.FromJson(contact));
                }
            }

            return new Business(
                id: json.GetProperty("id").GetString()!,
                name: json.GetProperty("name").GetString()!,
                customerId: json.GetProperty("customer_id").GetString()!,
                companyNumber: json.TryGetProperty("company_number", out JsonElement companyNumber) ? companyNumber.GetString() : null,
                taxIdentifier: json.TryGetProperty("tax_identifier", out JsonElement taxIdentifier) ? taxIdentifier.GetString() : null,
                status: Enum.Parse<Status>(json.GetProperty("status").GetString()!, true),
                contacts: contacts,
                createdAt: DateTime.Parse(json.GetProperty("created_at").GetString()!),
                updatedAt: DateTime.Parse(json.GetProperty("updated_at").GetString()!),
                customData: json.TryGetProperty("custom_data", out JsonElement customData) ? CustomData.FromJson(customData) : null,
                importMeta: json.TryGetProperty("import_meta", out JsonElement importMeta) ? ImportMeta.FromJson(importMeta) : null
            );
        }

        public static Business From(Dictionary<string, object> data)
        {
            JsonElement json = JsonSerializer.SerializeToElement(data);
            return FromJson(json);
        }
    }
}