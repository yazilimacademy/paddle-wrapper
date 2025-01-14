using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations;

public class ListTransactions : IHasParameters
{
    [JsonPropertyName("include")]
    public string? Include { get; set; }

    [JsonPropertyName("per_page")]
    public int? PerPage { get; set; }

    [JsonPropertyName("page")]
    public int? Page { get; set; }

    [JsonPropertyName("order_by")]
    public string? OrderBy { get; set; }

    public ListTransactions(string? include = null)
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

        if (PerPage.HasValue)
        {
            parameters.Add("per_page", PerPage.Value);
        }

        if (Page.HasValue)
        {
            parameters.Add("page", Page.Value);
        }

        if (!string.IsNullOrEmpty(OrderBy))
        {
            parameters.Add("order_by", OrderBy);
        }

        return parameters;
    }
}