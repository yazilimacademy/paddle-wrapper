using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class DiscountInfo
    {
        public string Id { get; }
        public string Status { get; }
        public string Description { get; }
        public string Code { get; }
        public Money Amount { get; }

        public DiscountInfo(
            string id,
            string status,
            string description,
            string code,
            Money amount)
        {
            Id = id;
            Status = status;
            Description = description;
            Code = code;
            Amount = amount;
        }

        public static DiscountInfo FromDict(JsonElement data)
        {
            var amountData = data.GetProperty("amount");
            var amount = new Money(
                amountData.GetProperty("amount").GetString(),
                Enum.Parse<CurrencyCode>(amountData.GetProperty("currency_code").GetString())
            );

            return new DiscountInfo(
                id: data.GetProperty("id").GetString(),
                status: data.GetProperty("status").GetString(),
                description: data.GetProperty("description").GetString(),
                code: data.GetProperty("code").GetString(),
                amount: amount
            );
        }
    }
} 