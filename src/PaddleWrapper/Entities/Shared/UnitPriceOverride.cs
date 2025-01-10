using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public class UnitPriceOverride
    {
        public string CountryCode { get; }
        public Money UnitPrice { get; }

        public UnitPriceOverride(string countryCode, Money unitPrice)
        {
            CountryCode = countryCode;
            UnitPrice = unitPrice;
        }

        public static UnitPriceOverride FromDict(JsonElement data)
        {
            var unitPriceData = data.GetProperty("unit_price");
            var unitPrice = new Money(
                unitPriceData.GetProperty("amount").GetString(),
                Enum.Parse<CurrencyCode>(unitPriceData.GetProperty("currency_code").GetString())
            );

            return new UnitPriceOverride(
                countryCode: data.GetProperty("country_code").GetString(),
                unitPrice: unitPrice
            );
        }
    }
} 