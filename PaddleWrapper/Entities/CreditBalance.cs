using PaddleWrapper.Entities.Adjustments;
using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class CreditBalance
    {
        [JsonPropertyName("customer_id")]
        public string CustomerId { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        [JsonPropertyName("balance")]
        public AdjustmentCustomerBalance Balance { get; }

        private CreditBalance(
            string customerId,
            CurrencyCode currencyCode,
            AdjustmentCustomerBalance balance)
        {
            CustomerId = customerId;
            CurrencyCode = currencyCode;
            Balance = balance;
        }

        public static CreditBalance From(Dictionary<string, object> data)
        {
            return new CreditBalance(
                customerId: (string)data["customer_id"],
                currencyCode: Enum.Parse<CurrencyCode>((string)data["currency_code"], true),
                balance: AdjustmentCustomerBalance.From((Dictionary<string, object>)data["balance"])
            );
        }
    }
}