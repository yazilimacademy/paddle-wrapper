using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Customers
{
    /// <summary>
    /// Represents a customer in the Paddle system
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// The unique identifier for the customer
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The customer's name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The customer's email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The customer's status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The customer's locale
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Custom data associated with the customer
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// Marketing consent status
        /// </summary>
        [JsonProperty("marketing_consent")]
        public bool MarketingConsent { get; set; }

        /// <summary>
        /// The source of the customer
        /// </summary>
        [JsonProperty("source")]
        public CustomerSource Source { get; set; }

        /// <summary>
        /// Import metadata for the customer
        /// </summary>
        [JsonProperty("import_meta")]
        public object ImportMeta { get; set; }

        /// <summary>
        /// When the customer was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the customer was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Represents the source of a customer
    /// </summary>
    public class CustomerSource
    {
        /// <summary>
        /// The platform where the customer was created
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }

        /// <summary>
        /// The type of source
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}