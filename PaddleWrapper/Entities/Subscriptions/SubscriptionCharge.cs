using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
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
                currencyCode: Enum.Parse<CurrencyCode>((string)data["currency_code"], true)
            );
        }
    }
}