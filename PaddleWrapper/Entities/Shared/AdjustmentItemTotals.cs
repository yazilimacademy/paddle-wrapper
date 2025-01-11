using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class AdjustmentItemTotals
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        [JsonConstructor]
        public AdjustmentItemTotals(string subtotal, string tax, string total)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
        }

        public static AdjustmentItemTotals From(Dictionary<string, object> data)
        {
            return new AdjustmentItemTotals(
                subtotal: data["subtotal"].ToString(),
                tax: data["tax"].ToString(),
                total: data["total"].ToString()
            );
        }
    }
} 