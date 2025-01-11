using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Contacts
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("email")]
        public string Email { get; }

        [JsonConstructor]
        public Contacts(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public static Contacts From(Dictionary<string, object> data)
        {
            return new Contacts(
                name: data["name"].ToString(),
                email: data["email"].ToString()
            );
        }
    }
} 