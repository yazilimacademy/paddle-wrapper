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
            return new Address(
                id: json.GetProperty("id").GetString()!,
                customerId: json.GetProperty("customer_id").GetString()!,
                description: json.TryGetProperty("description", out JsonElement description) ? description.GetString() : null,
                firstLine: json.TryGetProperty("first_line", out JsonElement firstLine) ? firstLine.GetString() : null,
                secondLine: json.TryGetProperty("second_line", out JsonElement secondLine) ? secondLine.GetString() : null,
                city: json.TryGetProperty("city", out JsonElement city) ? city.GetString() : null,
                postalCode: json.TryGetProperty("postal_code", out JsonElement postalCode) ? postalCode.GetString() : null,
                region: json.TryGetProperty("region", out JsonElement region) ? region.GetString() : null,
                countryCode: Enum.Parse<CountryCode>(json.GetProperty("country_code").GetString()!, true),
                customData: json.TryGetProperty("custom_data", out JsonElement customData) ? CustomData.FromJson(customData) : null,
                status: Enum.Parse<Status>(json.GetProperty("status").GetString()!, true),
                createdAt: DateTime.Parse(json.GetProperty("created_at").GetString()!),
                updatedAt: DateTime.Parse(json.GetProperty("updated_at").GetString()!),
                importMeta: json.TryGetProperty("import_meta", out JsonElement importMeta) ? ImportMeta.FromJson(importMeta) : null);
        }

        public static Address From(Dictionary<string, object> data)
        {
            JsonElement json = JsonSerializer.SerializeToElement(data);
            return FromJson(json);
        }
    }
}