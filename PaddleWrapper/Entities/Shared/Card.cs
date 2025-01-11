using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Card
    {
        [JsonPropertyName("type")]
        public TransactionCardType Type { get; }

        [JsonPropertyName("last4")]
        public string Last4 { get; }

        [JsonPropertyName("expiry_month")]
        public int ExpiryMonth { get; }

        [JsonPropertyName("expiry_year")]
        public int ExpiryYear { get; }

        [JsonPropertyName("cardholder_name")]
        public string? CardholderName { get; }

        [JsonConstructor]
        public Card(
            TransactionCardType type,
            string last4,
            int expiryMonth,
            int expiryYear,
            string? cardholderName = null)
        {
            Type = type;
            Last4 = last4;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            CardholderName = cardholderName;
        }

        public static Card From(Dictionary<string, object> data)
        {
            return new Card(
                type: Enum.Parse<TransactionCardType>(data["type"].ToString(), true),
                last4: data["last4"].ToString(),
                expiryMonth: Convert.ToInt32(data["expiry_month"]),
                expiryYear: Convert.ToInt32(data["expiry_year"]),
                cardholderName: data.ContainsKey("cardholder_name") ? data["cardholder_name"]?.ToString() : null
            );
        }
    }
}