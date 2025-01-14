using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class TaxRatesUsed
{
    [JsonPropertyName("tax_rate")]
    public string TaxRate { get; }

    [JsonPropertyName("totals")]
    public Totals Totals { get; }

    private TaxRatesUsed(string taxRate, Totals totals)
    {
        TaxRate = taxRate;
        Totals = totals;
    }

    public static TaxRatesUsed FromJson(JsonElement element)
    {
        return new TaxRatesUsed(
            element.GetProperty("tax_rate").GetString()!,
            Totals.FromJson(element.GetProperty("totals"))
        );
    }
}