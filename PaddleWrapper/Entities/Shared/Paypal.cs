using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Paypal
    {
        [JsonPropertyName("email")]
        public string Email { get; }

        [JsonPropertyName("reference")]
        public string Reference { get; }

        [JsonConstructor]
        public Paypal(string email, string reference)
        {
            Email = email;
            Reference = reference;
        }

        public static Paypal From(Dictionary<string, object> data)
        {
            return new Paypal(
                email: data["email"].ToString(),
                reference: data["reference"].ToString()
            );
        }
    }
}