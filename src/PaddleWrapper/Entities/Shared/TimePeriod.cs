using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class TimePeriod
    {
        [JsonPropertyName("interval")]
        public Interval Interval { get; }

        [JsonPropertyName("frequency")]
        public int Frequency { get; }

        [JsonConstructor]
        public TimePeriod(Interval interval, int frequency)
        {
            Interval = interval;
            Frequency = frequency;
        }

        public static TimePeriod From(Dictionary<string, object> data)
        {
            return new TimePeriod(
                interval: Enum.Parse<Interval>(data["interval"].ToString(), true),
                frequency: Convert.ToInt32(data["frequency"])
            );
        }
    }
}