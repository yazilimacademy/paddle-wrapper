using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionCredit
    {
        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        private SubscriptionCredit(
            string amount,
            CurrencyCode currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public static SubscriptionCredit From(Dictionary<string, object> data)
        {
            return new SubscriptionCredit(
                amount: (string)data["amount"],
                currencyCode: System.Enum.Parse<CurrencyCode>((string)data["currency_code"], true)
            );
        }
    }
}