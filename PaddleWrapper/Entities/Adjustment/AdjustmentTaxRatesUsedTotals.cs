using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Adjustment
{
    public class AdjustmentTaxRatesUsedTotals
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        [JsonConstructor]
        public AdjustmentTaxRatesUsedTotals(string subtotal, string tax, string total)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
        }

        public static AdjustmentTaxRatesUsedTotals From(Dictionary<string, object> data)
        {
            return new AdjustmentTaxRatesUsedTotals(
                data["subtotal"].ToString(),
                data["tax"].ToString(),
                data["total"].ToString()
            );
        }
    }
}