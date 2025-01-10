using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public class Contact
    {
        public string Name { get; }
        public string Email { get; }

        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public static Contact FromDict(JsonElement data)
        {
            return new Contact(
                data.GetProperty("name").GetString(),
                data.GetProperty("email").GetString()
            );
        }
    }
} 