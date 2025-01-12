using System.Text.Json;

namespace PaddleWrapper;

public sealed class ResponseParser
{
    public static async Task<T> ParseResponse<T>(HttpResponseMessage response) where T : class
    {
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {content}");
        }

        try
        {
            JsonDocument jsonDocument = JsonDocument.Parse(content);
            JsonElement root = jsonDocument.RootElement;

            if (root.TryGetProperty("data", out JsonElement data))
            {
                return JsonSerializer.Deserialize<T>(data.GetRawText());
            }

            throw new JsonException("Response does not contain 'data' property");
        }
        catch (JsonException ex)
        {
            throw new JsonException($"Failed to parse response: {ex.Message}", ex);
        }
    }

    public static async Task<IList<T>> ParseResponseList<T>(HttpResponseMessage response) where T : class
    {
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {content}");
        }

        try
        {
            JsonDocument jsonDocument = JsonDocument.Parse(content);
            JsonElement root = jsonDocument.RootElement;

            if (root.TryGetProperty("data", out JsonElement data))
            {
                return JsonSerializer.Deserialize<List<T>>(data.GetRawText());
            }

            throw new JsonException("Response does not contain 'data' property");
        }
        catch (JsonException ex)
        {
            throw new JsonException($"Failed to parse response: {ex.Message}", ex);
        }
    }
}