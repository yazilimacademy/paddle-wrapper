using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities;

public class NotificationLog
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("notification_id")]
    public string NotificationId { get; set; }

    [JsonPropertyName("notification_setting_id")]
    public string NotificationSettingId { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("attempts")]
    public int Attempts { get; set; }

    [JsonPropertyName("last_attempt_at")]
    public DateTime? LastAttemptAt { get; set; }

    [JsonPropertyName("next_attempt_at")]
    public DateTime? NextAttemptAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public static NotificationLog FromJson(JsonElement element)
    {
        return new NotificationLog
        {
            Id = element.GetProperty("id").GetString() ?? string.Empty,
            NotificationId = element.GetProperty("notification_id").GetString() ?? string.Empty,
            NotificationSettingId = element.GetProperty("notification_setting_id").GetString() ?? string.Empty,
            Success = element.GetProperty("success").GetBoolean(),
            Attempts = element.GetProperty("attempts").GetInt32(),
            LastAttemptAt = element.TryGetProperty("last_attempt_at", out JsonElement lastAttemptAt) ?
                DateTime.Parse(lastAttemptAt.GetString() ?? string.Empty) : null,
            NextAttemptAt = element.TryGetProperty("next_attempt_at", out JsonElement nextAttemptAt) ?
                DateTime.Parse(nextAttemptAt.GetString() ?? string.Empty) : null,
            CreatedAt = DateTime.Parse(element.GetProperty("created_at").GetString() ?? string.Empty),
            UpdatedAt = DateTime.Parse(element.GetProperty("updated_at").GetString() ?? string.Empty)
        };
    }

    public static NotificationLog From(Dictionary<string, object> data)
    {
        return new NotificationLog
        {
            Id = (string)data["id"],
            NotificationId = (string)data["notification_id"],
            NotificationSettingId = (string)data["notification_setting_id"],
            Success = (bool)data["success"],
            Attempts = (int)data["attempts"],
            LastAttemptAt = data.ContainsKey("last_attempt_at") ?
                DateTime.Parse((string)data["last_attempt_at"]) : null,
            NextAttemptAt = data.ContainsKey("next_attempt_at") ?
                DateTime.Parse((string)data["next_attempt_at"]) : null,
            CreatedAt = DateTime.Parse((string)data["created_at"]),
            UpdatedAt = DateTime.Parse((string)data["updated_at"])
        };
    }
}