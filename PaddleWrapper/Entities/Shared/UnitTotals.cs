using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class UnitTotals
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("discount")]
        public string Discount { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        [JsonConstructor]
        public UnitTotals(string subtotal, string discount, string tax, string total)
        {
            Subtotal = subtotal;
            Discount = discount;
            Tax = tax;
            Total = total;
        }

        public static UnitTotals From(Dictionary<string, object> data)
        {
            return new UnitTotals(
                subtotal: data["subtotal"].ToString(),
                discount: data["discount"].ToString(),
                tax: data["tax"].ToString(),
                total: data["total"].ToString()
            );
        }
    }
} 