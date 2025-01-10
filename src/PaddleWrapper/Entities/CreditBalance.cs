using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class CreditBalance : Entity
    {
        public string CustomerId { get; }
        public CurrencyCode CurrencyCode { get; }
        public string Balance { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public CreditBalance(
            string id,
            string customerId,
            CurrencyCode currencyCode,
            string balance,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            CustomerId = customerId;
            CurrencyCode = currencyCode;
            Balance = balance;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static CreditBalance FromDict(JsonElement data)
        {
            return new CreditBalance(
                id: data.GetProperty("id").GetString(),
                customerId: data.GetProperty("customer_id").GetString(),
                currencyCode: Enum.Parse<CurrencyCode>(data.GetProperty("currency_code").GetString()),
                balance: data.GetProperty("balance").GetString(),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString())
            );
        }
    }
} 