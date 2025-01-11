using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class AddressPreview
{
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("country_code")]
    public CountryCode CountryCode { get; set; }

    public static AddressPreview FromJson(JsonElement data)
    {
        return new AddressPreview
        {
            PostalCode = data.TryGetProperty("postal_code", out var postalCode) ? postalCode.GetString() : null,
            CountryCode = JsonSerializer.Deserialize<CountryCode>(data.GetProperty("country_code").GetRawText())
        };
    }
} 