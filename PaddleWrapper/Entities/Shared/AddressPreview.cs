using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class AddressPreview
    {
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; }

        [JsonPropertyName("country_code")]
        public CountryCode CountryCode { get; }

        [JsonConstructor]
        public AddressPreview(string? postalCode, CountryCode countryCode)
        {
            PostalCode = postalCode;
            CountryCode = countryCode;
        }

        public static AddressPreview From(Dictionary<string, object> data)
        {
            return new AddressPreview(
                postalCode: data.ContainsKey("postal_code") ? data["postal_code"]?.ToString() : null,
                countryCode: Enum.Parse<CountryCode>(data["country_code"].ToString(), true)
            );
        }
    }
}