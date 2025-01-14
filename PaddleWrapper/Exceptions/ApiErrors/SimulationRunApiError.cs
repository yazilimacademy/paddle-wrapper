using System.Text.Json;

namespace PaddleWrapper.Exceptions.ApiErrors;

public class SimulationRunApiError : ApiError
{
    public SimulationRunApiError(string type, string code, string detail, string documentationUrl, List<FieldError> fieldErrors)
        : base(type, code, detail, documentationUrl, fieldErrors)
    {
    }

    public static SimulationRunApiError FromJson(JsonElement root)
    {
        JsonElement error = root.GetProperty("error");

        return new SimulationRunApiError(
            error.GetProperty("type").GetString() ?? string.Empty,
            error.GetProperty("code").GetString() ?? string.Empty,
            error.GetProperty("detail").GetString() ?? string.Empty,
            error.GetProperty("documentation_url").GetString() ?? string.Empty,
            error.TryGetProperty("field_errors", out JsonElement fieldErrors)
                ? fieldErrors.EnumerateArray()
                    .Select(FieldError.FromJson)
                    .ToList()
                : new List<FieldError>()
        );
    }
}