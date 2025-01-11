using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaddleWrapper;

public sealed class ResponseParser
{
    public static async Task<T> ParseResponse<T>(HttpResponseMessage response) where T : class
    {
        var content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {content}");
        }

        try
        {
            var jsonDocument = JsonDocument.Parse(content);
            var root = jsonDocument.RootElement;

            if (root.TryGetProperty("data", out var data))
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
        var content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {content}");
        }

        try
        {
            var jsonDocument = JsonDocument.Parse(content);
            var root = jsonDocument.RootElement;

            if (root.TryGetProperty("data", out var data))
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