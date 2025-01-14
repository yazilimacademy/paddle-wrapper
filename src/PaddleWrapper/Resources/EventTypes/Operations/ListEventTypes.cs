using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.EventTypes.Operations;

public class ListEventTypes
{
    [JsonPropertyName("per_page")]
    public int? PerPage { get; set; }

    [JsonPropertyName("page")]
    public int? Page { get; set; }

    [JsonPropertyName("order_by")]
    public string? OrderBy { get; set; }
}