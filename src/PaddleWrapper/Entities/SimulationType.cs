using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities;

public class SimulationType
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    public static SimulationType FromJson(JsonElement element)
    {
        return new SimulationType
        {
            Id = element.GetProperty("id").GetString() ?? string.Empty,
            Name = element.GetProperty("name").GetString() ?? string.Empty,
            Description = element.GetProperty("description").GetString() ?? string.Empty
        };
    }
}