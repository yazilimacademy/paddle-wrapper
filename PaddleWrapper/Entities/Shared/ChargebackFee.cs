using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class ChargebackFee
    {
        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("original")]
        public Original? Original { get; }

        [JsonConstructor]
        public ChargebackFee(string amount, Original? original = null)
        {
            Amount = amount;
            Original = original;
        }

        public static ChargebackFee From(Dictionary<string, object> data)
        {
            return new ChargebackFee(
                amount: data["amount"].ToString(),
                original: data.ContainsKey("original") && data["original"] != null
                    ? Original.From((Dictionary<string, object>)data["original"])
                    : null
            );
        }
    }
} 