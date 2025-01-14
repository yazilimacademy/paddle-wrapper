using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class CustomerAuthToken
    {
        [JsonPropertyName("customer_auth_token")]
        public string CustomerAuthTokenValue { get; }

        [JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; }

        private CustomerAuthToken(
            string customerAuthToken,
            DateTime expiresAt)
        {
            CustomerAuthTokenValue = customerAuthToken;
            ExpiresAt = expiresAt;
        }

        public static CustomerAuthToken FromJson(JsonElement json)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()));
        }

        public static CustomerAuthToken From(Dictionary<string, object> data)
        {
            return new CustomerAuthToken(
                customerAuthToken: (string)data["customer_auth_token"],
                expiresAt: DateTime.Parse((string)data["expires_at"])
            );
        }
    }
}