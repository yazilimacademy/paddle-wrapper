using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Businesses;

public class BusinessesContacts
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    public static BusinessesContacts FromJson(JsonElement data)
    {
        return new BusinessesContacts
        {
            Name = data.GetProperty("name").GetString()!,
            Email = data.GetProperty("email").GetString()!
        };
    }
}