using PaddleWrapper.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class Address
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; }

        [JsonPropertyName("description")]
        public string? Description { get; }

        [JsonPropertyName("first_line")]
        public string? FirstLine { get; }

        [JsonPropertyName("second_line")]
        public string? SecondLine { get; }

        [JsonPropertyName("city")]
        public string? City { get; }

        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; }

        [JsonPropertyName("region")]
        public string? Region { get; }

        [JsonPropertyName("country_code")]
        public CountryCode CountryCode { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        [JsonPropertyName("status")]
        public Status Status { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        [JsonPropertyName("import_meta")]
        public ImportMeta? ImportMeta { get; }

        private Address(
            string id,
            string customerId,
            string? description,
            string? firstLine,
            string? secondLine,
            string? city,
            string? postalCode,
            string? region,
            CountryCode countryCode,
            CustomData? customData,
            Status status,
            DateTime createdAt,
            DateTime updatedAt,
            ImportMeta? importMeta)
        {
            Id = id;
            CustomerId = customerId;
            Description = description;
            FirstLine = firstLine;
            SecondLine = secondLine;
            City = city;
            PostalCode = postalCode;
            Region = region;
            CountryCode = countryCode;
            CustomData = customData;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ImportMeta = importMeta;
        }

        public static Address FromJson(JsonElement json)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()));
        }

        public static Address From(Dictionary<string, object> data)
        {
            return new Address(
                id: (string)data["id"],
                customerId: (string)data["customer_id"],
                description: data.ContainsKey("description") ? (string?)data["description"] : null,
                firstLine: data.ContainsKey("first_line") ? (string?)data["first_line"] : null,
                secondLine: data.ContainsKey("second_line") ? (string?)data["second_line"] : null,
                city: data.ContainsKey("city") ? (string?)data["city"] : null,
                postalCode: data.ContainsKey("postal_code") ? (string?)data["postal_code"] : null,
                region: data.ContainsKey("region") ? (string?)data["region"] : null,
                countryCode: Enum.Parse<CountryCode>((string)data["country_code"], true),
                customData: data.ContainsKey("custom_data") ?
                    CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                status: Enum.Parse<Status>((string)data["status"], true),
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"]),
                importMeta: data.ContainsKey("import_meta") ?
                    ImportMeta.From((Dictionary<string, object>)data["import_meta"]) : null
            );
        }
    }
}