using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class PaymentMethod : Entity
    {
        public string CustomerId { get; }
        public PaymentMethodType Type { get; }
        public JsonElement Details { get; }
        public Status Status { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public PaymentMethod(
            string id,
            string customerId,
            PaymentMethodType type,
            JsonElement details,
            Status status,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            CustomerId = customerId;
            Type = type;
            Details = details;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static PaymentMethod FromDict(JsonElement data)
        {
            return new PaymentMethod(
                id: data.GetProperty("id").GetString(),
                customerId: data.GetProperty("customer_id").GetString(),
                type: Enum.Parse<PaymentMethodType>(data.GetProperty("type").GetString()),
                details: data.GetProperty("details"),
                status: Enum.Parse<Status>(data.GetProperty("status").GetString()),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString())
            );
        }
    }
} 