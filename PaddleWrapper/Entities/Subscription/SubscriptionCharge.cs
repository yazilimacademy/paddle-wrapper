using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionCharge
    {
        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        private SubscriptionCharge(
            string amount,
            CurrencyCode currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public static SubscriptionCharge From(Dictionary<string, object> data)
        {
            return new SubscriptionCharge(
                amount: (string)data["amount"],
                currencyCode: System.Enum.Parse<CurrencyCode>((string)data["currency_code"], true)
            );
        }
    }
} 