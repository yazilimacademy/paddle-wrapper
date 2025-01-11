using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class TimePeriod
{
    [JsonPropertyName("interval")]
    public Interval Interval { get; }

    [JsonPropertyName("frequency")]
    public int Frequency { get; }

    private TimePeriod(Interval interval, int frequency)
    {
        Interval = interval;
        Frequency = frequency;
    }

    public static TimePeriod FromJson(JsonElement element)
    {
        return new TimePeriod(
            JsonSerializer.Deserialize<Interval>(element.GetProperty("interval").GetRawText()),
            element.GetProperty("frequency").GetInt32()
        );
    }
} 