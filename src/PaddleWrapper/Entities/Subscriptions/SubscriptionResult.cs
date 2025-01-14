using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionResult
    {
        [JsonPropertyName("action")]
        public SubscriptionResultAction Action { get; }

        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        private SubscriptionResult(
            SubscriptionResultAction action,
            string amount,
            CurrencyCode currencyCode)
        {
            Action = action;
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public static SubscriptionResult From(Dictionary<string, object> data)
        {
            return new SubscriptionResult(
                action: Enum.Parse<SubscriptionResultAction>((string)data["action"], true),
                amount: (string)data["amount"],
                currencyCode: Enum.Parse<CurrencyCode>((string)data["currency_code"], true)
            );
        }
    }
}