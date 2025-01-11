using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class UnitPriceOverride
    {
        [JsonPropertyName("country_codes")]
        public List<CountryCode> CountryCodes { get; }

        [JsonPropertyName("unit_price")]
        public Money UnitPrice { get; }

        [JsonConstructor]
        public UnitPriceOverride(List<CountryCode> countryCodes, Money unitPrice)
        {
            CountryCodes = countryCodes;
            UnitPrice = unitPrice;
        }

        public static UnitPriceOverride From(Dictionary<string, object> data)
        {
            var countryCodesArray = (object[])data["country_codes"];
            return new UnitPriceOverride(
                countryCodes: countryCodesArray.Select(code => Enum.Parse<CountryCode>(code.ToString(), true)).ToList(),
                unitPrice: Money.From((Dictionary<string, object>)data["unit_price"])
            );
        }
    }
} 