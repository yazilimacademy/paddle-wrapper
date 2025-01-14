using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Subscriptions.Operations.Update;

public class BillingCycle
{
    [JsonPropertyName("interval")]
    public string Interval { get; set; }

    [JsonPropertyName("frequency")]
    public int Frequency { get; set; }

    public BillingCycle(string interval, int frequency)
    {
        Interval = interval;
        Frequency = frequency;
    }
}