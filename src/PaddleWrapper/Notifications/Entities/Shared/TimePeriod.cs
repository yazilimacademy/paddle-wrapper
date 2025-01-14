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

    public static TimePeriod? FromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        if (!element.TryGetProperty("interval", out JsonElement intervalElement))
        {
            throw new JsonException("TimePeriod interval is required");
        }

        if (!element.TryGetProperty("frequency", out JsonElement frequencyElement))
        {
            throw new JsonException("TimePeriod frequency is required");
        }

        return new TimePeriod(
            JsonSerializer.Deserialize<Interval>(intervalElement.GetRawText()),
            frequencyElement.GetInt32()
        );
    }
}