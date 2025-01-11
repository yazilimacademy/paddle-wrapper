using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Money
    {
        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode? CurrencyCode { get; }

        [JsonConstructor]
        public Money(string amount, CurrencyCode? currencyCode = null)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public static Money From(Dictionary<string, object> data)
        {
            return new Money(
                amount: data["amount"].ToString(),
                currencyCode: data.ContainsKey("currency_code") && !string.IsNullOrEmpty(data["currency_code"]?.ToString())
                    ? Enum.Parse<CurrencyCode>(data["currency_code"].ToString(), true)
                    : null
            );
        }
    }
}