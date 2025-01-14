using System.Text.Json;

namespace PaddleWrapper.Extensions;

public static class ClientExtension
{
    public static async Task<JsonDocument> Get(this Client client, string uri, object? parameters = null)
    {
        HttpResponseMessage response = await client.GetRawAsync(uri, parameters as IHasParameters);
        string content = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(content);
    }

    public static async Task<JsonDocument> Post(this Client client, string uri, object? payload = null, object? parameters = null)
    {
        HttpResponseMessage response = await client.PostRawAsync(uri, payload, parameters as IHasParameters);
        string content = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(content);
    }

    public static async Task<JsonDocument> Patch(this Client client, string uri, object payload)
    {
        HttpResponseMessage response = await client.PatchRawAsync(uri, payload);
        string content = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(content);
    }
}