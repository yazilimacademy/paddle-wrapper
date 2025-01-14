using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations;

public class GetTransaction : IHasParameters
{
    [JsonPropertyName("include")]
    public string? Include { get; set; }

    public GetTransaction(string? include = null)
    {
        Include = include;
    }

    public IDictionary<string, object> GetParameters()
    {
        Dictionary<string, object> parameters = new();

        if (!string.IsNullOrEmpty(Include))
        {
            parameters.Add("include", Include);
        }

        return parameters;
    }
}