using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class Discount : Entity
    {
        public string Description { get; }
        public string Code { get; }
        public Money Amount { get; }
        public bool IsRecurring { get; }
        public Status Status { get; }
        public CustomData CustomData { get; }
        public DateTime? ExpiresAt { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Discount(
            string id,
            string description,
            string code,
            Money amount,
            bool isRecurring,
            Status status,
            CustomData customData,
            DateTime? expiresAt,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            Description = description;
            Code = code;
            Amount = amount;
            IsRecurring = isRecurring;
            Status = status;
            CustomData = customData;
            ExpiresAt = expiresAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Discount FromDict(JsonElement data)
        {
            var amountData = data.GetProperty("amount");
            var amount = new Money(
                amountData.GetProperty("amount").GetString(),
                Enum.Parse<CurrencyCode>(amountData.GetProperty("currency_code").GetString())
            );

            return new Discount(
                id: data.GetProperty("id").GetString(),
                description: data.GetProperty("description").GetString(),
                code: data.GetProperty("code").GetString(),
                amount: amount,
                isRecurring: data.GetProperty("is_recurring").GetBoolean(),
                status: Enum.Parse<Status>(data.GetProperty("status").GetString()),
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                expiresAt: data.TryGetProperty("expires_at", out var expiresAt) ? DateTime.Parse(expiresAt.GetString()) : null,
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString())
            );
        }
    }
} 