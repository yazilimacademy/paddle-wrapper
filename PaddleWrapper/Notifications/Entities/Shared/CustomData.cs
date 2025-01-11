using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class CustomData
{
    [JsonPropertyName("data")]
    public JsonElement Data { get; }

    public CustomData(JsonElement data)
    {
        Data = data;
    }

    public static CustomData FromJson(JsonElement element)
    {
        return new CustomData(element);
    }
} 