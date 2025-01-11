using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Resources.Businesses.Operations
{
    public class UpdateBusiness
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("company_number")]
        public string? CompanyNumber { get; set; }

        [JsonPropertyName("tax_identifier")]
        public string? TaxIdentifier { get; set; }

        [JsonPropertyName("contacts")]
        public List<Contacts>? Contacts { get; set; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; set; }

        [JsonPropertyName("status")]
        public Status? Status { get; set; }

        public UpdateBusiness(
            string? name = null,
            string? companyNumber = null,
            string? taxIdentifier = null,
            List<Contacts>? contacts = null,
            CustomData? customData = null,
            Status? status = null)
        {
            Name = name;
            CompanyNumber = companyNumber;
            TaxIdentifier = taxIdentifier;
            Contacts = contacts;
            CustomData = customData;
            Status = status;
        }
    }
} 