using System.Text.Json;

namespace PaddleWrapper.Exceptions
{
    public class ApiError : Exception
    {
        public string Type { get; }
        public string Code { get; }
        public string Detail { get; }
        public string DocumentationUrl { get; }
        public List<FieldError> FieldErrors { get; }

        public ApiError(
            string type,
            string code,
            string detail,
            string documentationUrl,
            List<FieldError> fieldErrors = null) : base(detail)
        {
            Type = type;
            Code = code;
            Detail = detail;
            DocumentationUrl = documentationUrl;
            FieldErrors = fieldErrors ?? new List<FieldError>();
        }

        public static ApiError FromJson(JsonElement json)
        {
            JsonElement error = json.GetProperty("error");
            return new ApiError(
                type: error.GetProperty("type").GetString(),
                code: error.GetProperty("code").GetString(),
                detail: error.GetProperty("detail").GetString(),
                documentationUrl: error.GetProperty("documentation_url").GetString(),
                fieldErrors: error.TryGetProperty("field_errors", out JsonElement fieldErrors)
                    ? fieldErrors.EnumerateArray()
                        .Select(fe => new FieldError(
                            field: fe.GetProperty("field").GetString(),
                            code: fe.GetProperty("code").GetString(),
                            message: fe.GetProperty("message").GetString()))
                        .ToList()
                    : null
            );
        }
    }
}