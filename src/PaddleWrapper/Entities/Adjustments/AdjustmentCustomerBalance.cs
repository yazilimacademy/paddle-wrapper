using System.Text.Json;

namespace PaddleWrapper.Entities.Adjustments
{
    public class AdjustmentCustomerBalance
    {
        public string Available { get; }
        public string Reserved { get; }
        public string Used { get; }

        public AdjustmentCustomerBalance(string available, string reserved, string used)
        {
            Available = available;
            Reserved = reserved;
            Used = used;
        }

        public static AdjustmentCustomerBalance FromDict(JsonElement data)
        {
            return new AdjustmentCustomerBalance(
                data.GetProperty("available").GetString(),
                data.GetProperty("reserved").GetString(),
                data.GetProperty("used").GetString()
            );
        }
    }
} 