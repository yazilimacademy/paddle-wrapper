using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class ChargebackFee
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("original")]
    public Original? Original { get; set; }

    public static ChargebackFee FromJson(JsonElement data)
    {
        return new ChargebackFee
        {
            Amount = data.GetProperty("amount").GetString()!,
            Original = data.TryGetProperty("original", out JsonElement original) ? Original.FromJson(original) : null
        };
    }
}