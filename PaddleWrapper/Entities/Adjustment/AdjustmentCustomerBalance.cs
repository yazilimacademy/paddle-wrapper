using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Adjustment
{
    public class AdjustmentCustomerBalance
    {
        [JsonPropertyName("available")]
        public string Available { get; }

        [JsonPropertyName("reserved")]
        public string Reserved { get; }

        [JsonPropertyName("used")]
        public string Used { get; }

        [JsonConstructor]
        public AdjustmentCustomerBalance(string available, string reserved, string used)
        {
            Available = available;
            Reserved = reserved;
            Used = used;
        }

        public static AdjustmentCustomerBalance From(Dictionary<string, object> data)
        {
            return new AdjustmentCustomerBalance(
                data["available"].ToString(),
                data["reserved"].ToString(),
                data["used"].ToString()
            );
        }
    }
}