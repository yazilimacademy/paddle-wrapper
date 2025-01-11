using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class TaxRatesUsed
    {
        [JsonPropertyName("tax_rate")]
        public string TaxRate { get; }

        [JsonPropertyName("totals")]
        public Totals Totals { get; }

        [JsonConstructor]
        public TaxRatesUsed(string taxRate, Totals totals)
        {
            TaxRate = taxRate;
            Totals = totals;
        }

        public static TaxRatesUsed From(Dictionary<string, object> data)
        {
            return new TaxRatesUsed(
                taxRate: data["tax_rate"].ToString(),
                totals: Totals.From((Dictionary<string, object>)data["totals"])
            );
        }
    }
} 