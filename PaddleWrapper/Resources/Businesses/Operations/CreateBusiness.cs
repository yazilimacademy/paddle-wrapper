using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Resources.Businesses.Operations
{
    public class CreateBusiness
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("company_number")]
        public string? CompanyNumber { get; set; }

        [JsonPropertyName("tax_identifier")]
        public string? TaxIdentifier { get; set; }

        [JsonPropertyName("contacts")]
        public List<Contacts>? Contacts { get; set; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; set; }

        public CreateBusiness(
            string name,
            string? companyNumber = null,
            string? taxIdentifier = null,
            List<Contacts>? contacts = null,
            CustomData? customData = null)
        {
            Name = name;
            CompanyNumber = companyNumber;
            TaxIdentifier = taxIdentifier;
            Contacts = contacts;
            CustomData = customData;
        }
    }
} 