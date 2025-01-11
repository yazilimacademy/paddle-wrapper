using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Original
    {
        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCodeAdjustments CurrencyCode { get; }

        [JsonConstructor]
        public Original(string amount, CurrencyCodeAdjustments currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public static Original From(Dictionary<string, object> data)
        {
            return new Original(
                amount: data["amount"].ToString(),
                currencyCode: Enum.Parse<CurrencyCodeAdjustments>(data["currency_code"].ToString(), true)
            );
        }
    }
}