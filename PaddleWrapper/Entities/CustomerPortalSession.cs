using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.CustomerPortalSession;

namespace PaddleWrapper.Entities
{
    public class CustomerPortalSession
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; }

        [JsonPropertyName("urls")]
        public CustomerPortalSessionUrls Urls { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        private CustomerPortalSession(
            string id,
            string customerId,
            CustomerPortalSessionUrls urls,
            DateTime createdAt)
        {
            Id = id;
            CustomerId = customerId;
            Urls = urls;
            CreatedAt = createdAt;
        }

        public static CustomerPortalSession From(Dictionary<string, object> data)
        {
            return new CustomerPortalSession(
                id: (string)data["id"],
                customerId: (string)data["customer_id"],
                urls: CustomerPortalSessionUrls.From((Dictionary<string, object>)data["urls"]),
                createdAt: DateTime.Parse((string)data["created_at"])
            );
        }
    }
} 