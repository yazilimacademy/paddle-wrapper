using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxMode
{
    [JsonPropertyName("account_setting")]
    AccountSetting,
    [JsonPropertyName("external")]
    External,
    [JsonPropertyName("internal")]
    Internal
} 