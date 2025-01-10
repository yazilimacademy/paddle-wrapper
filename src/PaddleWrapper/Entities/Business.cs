using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class Business : Entity
    {
        public string CustomerId { get; }
        public string Name { get; }
        public string CompanyNumber { get; }
        public string TaxIdentifier { get; }
        public Status Status { get; }
        public List<Contact> Contacts { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public CustomData CustomData { get; }
        public ImportMeta ImportMeta { get; }

        public Business(
            string id,
            string customerId,
            string name,
            string companyNumber,
            string taxIdentifier,
            Status status,
            List<Contact> contacts,
            DateTime createdAt,
            DateTime updatedAt,
            CustomData customData = null,
            ImportMeta importMeta = null)
        {
            Id = id;
            CustomerId = customerId;
            Name = name;
            CompanyNumber = companyNumber;
            TaxIdentifier = taxIdentifier;
            Status = status;
            Contacts = contacts;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CustomData = customData;
            ImportMeta = importMeta;
        }

        public static Business FromDict(JsonElement data)
        {
            return new Business(
                id: data.GetProperty("id").GetString(),
                customerId: data.GetProperty("customer_id").GetString(),
                name: data.GetProperty("name").GetString(),
                companyNumber: data.TryGetProperty("company_number", out var companyNumber) ? companyNumber.GetString() : null,
                taxIdentifier: data.TryGetProperty("tax_identifier", out var taxId) ? taxId.GetString() : null,
                status: Enum.Parse<Status>(data.GetProperty("status").GetString()),
                contacts: data.GetProperty("contacts").EnumerateArray().Select(Contact.FromDict).ToList(),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString()),
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                importMeta: data.TryGetProperty("import_meta", out var importMeta) ? ImportMeta.FromDict(importMeta) : null
            );
        }
    }
} 