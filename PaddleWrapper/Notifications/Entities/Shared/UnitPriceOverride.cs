using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class UnitPriceOverride
{
    [JsonPropertyName("country_codes")]
    public CountryCode[] CountryCodes { get; }

    [JsonPropertyName("unit_price")]
    public Money UnitPrice { get; }

    private UnitPriceOverride(CountryCode[] countryCodes, Money unitPrice)
    {
        CountryCodes = countryCodes;
        UnitPrice = unitPrice;
    }

    public static UnitPriceOverride FromJson(JsonElement json)
    {
        var countryCodes = json.GetProperty("country_codes").EnumerateArray()
            .Select(x => JsonSerializer.Deserialize<CountryCode>(x.GetRawText()))
            .Where(x => x != null)
            .ToArray()!;

        Money unitPrice = Money.FromJson(json.GetProperty("unit_price"));

        return new UnitPriceOverride(countryCodes, unitPrice);
    }
}