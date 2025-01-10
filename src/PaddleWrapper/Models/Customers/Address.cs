using Newtonsoft.Json;
using System;

namespace PaddleWrapper.Models.Customers
{
    /// <summary>
    /// Represents a customer address in the Paddle system
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The unique identifier for the address
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the customer this address belongs to
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// The description of the address
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// First line of the address
        /// </summary>
        [JsonProperty("first_line")]
        public string FirstLine { get; set; }

        /// <summary>
        /// Second line of the address
        /// </summary>
        [JsonProperty("second_line")]
        public string SecondLine { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// The postal/zip code
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The region/state/county
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// The country code (ISO 3166-1 alpha-2)
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Custom data associated with the address
        /// </summary>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// The status of the address
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// When the address was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the address was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}