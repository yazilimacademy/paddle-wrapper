using System.Text.Json;

namespace PaddleWrapper.Entities.Adjustments
{
    public class AdjustmentTotals
    {
        public string Subtotal { get; }
        public string Tax { get; }
        public string Total { get; }

        public AdjustmentTotals(string subtotal, string tax, string total)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
        }

        public static AdjustmentTotals FromDict(JsonElement data)
        {
            return new AdjustmentTotals(
                data.GetProperty("subtotal").GetString(),
                data.GetProperty("tax").GetString(),
                data.GetProperty("total").GetString()
            );
        }
    }
} 