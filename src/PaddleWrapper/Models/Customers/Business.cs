using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Customers
{
    /// <summary>
    /// Represents a customer business in the Paddle system
    /// </summary>
    public class Business
    {
        /// <summary>
        /// The unique identifier for the business
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the customer this business belongs to
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// The name of the business
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The company number/registration number
        /// </summary>
        [JsonProperty("company_number")]
        public string CompanyNumber { get; set; }

        /// <summary>
        /// The tax number/VAT number
        /// </summary>
        [JsonProperty("tax_identifier")]
        public string TaxIdentifier { get; set; }

        /// <summary>
        /// Custom data associated with the business
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// The status of the business
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The contacts associated with the business
        /// </summary>
        [JsonProperty("contacts")]
        public BusinessContact[] Contacts { get; set; }

        /// <summary>
        /// When the business was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the business was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Represents a contact for a business
    /// </summary>
    public class BusinessContact
    {
        /// <summary>
        /// The name of the contact
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The email address of the contact
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}