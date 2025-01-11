using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class PaymentMethod
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; }

        [JsonPropertyName("address_id")]
        public string AddressId { get; }

        [JsonPropertyName("type")]
        public SavedPaymentMethodType Type { get; }

        [JsonPropertyName("card")]
        public Card? Card { get; }

        [JsonPropertyName("paypal")]
        public Paypal? Paypal { get; }

        [JsonPropertyName("origin")]
        public SavedPaymentMethodOrigin Origin { get; }

        [JsonPropertyName("saved_at")]
        public DateTime SavedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        private PaymentMethod(
            string id,
            string customerId,
            string addressId,
            SavedPaymentMethodType type,
            Card? card,
            Paypal? paypal,
            SavedPaymentMethodOrigin origin,
            DateTime savedAt,
            DateTime updatedAt)
        {
            Id = id;
            CustomerId = customerId;
            AddressId = addressId;
            Type = type;
            Card = card;
            Paypal = paypal;
            Origin = origin;
            SavedAt = savedAt;
            UpdatedAt = updatedAt;
        }

        public static PaymentMethod From(Dictionary<string, object> data)
        {
            return new PaymentMethod(
                id: (string)data["id"],
                customerId: (string)data["customer_id"],
                addressId: (string)data["address_id"],
                type: System.Enum.Parse<SavedPaymentMethodType>((string)data["type"], true),
                card: data.ContainsKey("card") ? Card.From((Dictionary<string, object>)data["card"]) : null,
                paypal: data.ContainsKey("paypal") ? Paypal.From((Dictionary<string, object>)data["paypal"]) : null,
                origin: System.Enum.Parse<SavedPaymentMethodOrigin>((string)data["origin"], true),
                savedAt: DateTime.Parse((string)data["saved_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"])
            );
        }
    }
} 