using PaddleWrapper.Entities.Shared;
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

        public static Business From(Dictionary<string, object> data)
        {
            List<Contacts> contacts = new();
            if (data.ContainsKey("contacts"))
            {
                object[] contactsData = (object[])data["contacts"];
                foreach (object contact in contactsData)
                {
                    contacts.Add(Contacts.From((Dictionary<string, object>)contact));
                }
            }

            return new Business(
                id: (string)data["id"],
                name: (string)data["name"],
                customerId: (string)data["customer_id"],
                companyNumber: data.ContainsKey("company_number") ? (string?)data["company_number"] : null,
                taxIdentifier: data.ContainsKey("tax_identifier") ? (string?)data["tax_identifier"] : null,
                status: System.Enum.Parse<Status>((string)data["status"], true),
                contacts: contacts,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"]),
                customData: data.ContainsKey("custom_data") ?
                    CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                importMeta: data.ContainsKey("import_meta") ?
                    ImportMeta.From((Dictionary<string, object>)data["import_meta"]) : null
            );
        }
    }
}