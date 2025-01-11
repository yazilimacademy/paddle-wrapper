using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
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
                currencyCode: Enum.Parse<CurrencyCode>((string)data["currency_code"], true)
            );
        }
    }
}