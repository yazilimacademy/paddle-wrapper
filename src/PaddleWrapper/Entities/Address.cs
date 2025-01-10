using System;
using System.Text.Json;

namespace PaddleWrapper.Entities
{
    public class Address : Entity
    {
        public string CustomerId { get; }
        public string Description { get; }
        public string FirstLine { get; }
        public string SecondLine { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string Region { get; }
        public CountryCode CountryCode { get; }
        public CustomData CustomData { get; }
        public Status Status { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public ImportMeta ImportMeta { get; }

        public Address(
            string id,
            string customerId,
            string description,
            string firstLine,
            string secondLine,
            string city,
            string postalCode,
            string region,
            CountryCode countryCode,
            CustomData customData,
            Status status,
            DateTime createdAt,
            DateTime updatedAt,
            ImportMeta importMeta)
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

        public static Address FromDict(JsonElement data)
        {
            return new Address(
                id: data.GetProperty("id").GetString(),
                customerId: data.GetProperty("customer_id").GetString(),
                description: data.GetProperty("description").GetString(),
                firstLine: data.GetProperty("first_line").GetString(),
                secondLine: data.GetProperty("second_line").GetString(),
                city: data.GetProperty("city").GetString(),
                postalCode: data.GetProperty("postal_code").GetString(),
                region: data.GetProperty("region").GetString(),
                countryCode: Enum.Parse<CountryCode>(data.GetProperty("country_code").GetString()),
                status: Enum.Parse<Status>(data.GetProperty("status").GetString()),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString()),
                customData: data.TryGetProperty("custom_data", out var customData) ? 
                    new CustomData(customData) : null,
                importMeta: data.TryGetProperty("import_meta", out var importMeta) ? 
                    ImportMeta.FromDict(importMeta) : null
            );
        }
    }
} 