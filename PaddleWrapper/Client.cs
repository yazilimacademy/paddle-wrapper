using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PaddleWrapper;

public sealed class Client : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly Options _options;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public Client(Options options)
    {
        _options = options;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_options.Environment.GetBaseUrl())
        };

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _options.ApiKey);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<T> Get<T>(string endpoint, IDictionary<string, object> parameters = null) where T : class
    {
        string queryString = BuildQueryString(parameters);
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}{queryString}");
        return await ResponseParser.ParseResponse<T>(response);
    }

    public async Task<HttpResponseMessage> GetRaw(string endpoint, IDictionary<string, object> parameters = null)
    {
        string queryString = BuildQueryString(parameters);
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}{queryString}");
        return response;
    }

    public async Task<IList<T>> GetList<T>(string endpoint, IDictionary<string, object> parameters = null) where T : class
    {
        string queryString = BuildQueryString(parameters);
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}{queryString}");
        return await ResponseParser.ParseResponseList<T>(response);
    }

    public async Task<T> Post<T>(string endpoint, object data) where T : class
    {
        string json = JsonSerializer.Serialize(data, _jsonSerializerOptions);
        StringContent content = new(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
        return await ResponseParser.ParseResponse<T>(response);
    }

    public async Task<T> Patch<T>(string endpoint, object data) where T : class
    {
        string json = JsonSerializer.Serialize(data, _jsonSerializerOptions);
        StringContent content = new(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PatchAsync(endpoint, content);
        return await ResponseParser.ParseResponse<T>(response);
    }

    private static string BuildQueryString(IDictionary<string, object> parameters)
    {
        if (parameters == null || parameters.Count == 0)
        {
            return string.Empty;
        }

        List<string> queryParams = new();
        foreach ((string key, object value) in parameters)
        {
            if (value == null || value == Undefined.Instance)
            {
                continue;
            }

            string encodedValue = Uri.EscapeDataString(value.ToString());
            queryParams.Add($"{key}={encodedValue}");
        }

        return queryParams.Count > 0 ? $"?{string.Join("&", queryParams)}" : string.Empty;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}