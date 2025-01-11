using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class Data
{
    [JsonPropertyName("data")]
    public JsonElement Data { get; }

    private Data(JsonElement data)
    {
        Data = data;
    }

    public static Data FromJson(JsonElement element)
    {
        return new Data(element);
    }
} 