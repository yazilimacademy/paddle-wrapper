using System.Text.Json;

namespace PaddleWrapper.Exceptions
{
    public class ApiError : HttpRequestException
    {
        public string ErrorType { get; }
        public string ErrorCode { get; }
        public string Detail { get; }
        public string DocsUrl { get; }
        public FieldError[] FieldErrors { get; }
        public HttpResponseMessage Response { get; }

        public ApiError(
            HttpResponseMessage response,
            string errorType,
            string errorCode,
            string detail,
            string docsUrl,
            params FieldError[] fieldErrors) : base(detail)
        {
            ErrorType = errorType;
            ErrorCode = errorCode;
            Detail = detail;
            DocsUrl = docsUrl;
            FieldErrors = fieldErrors ?? Array.Empty<FieldError>();
            Response = response;
        }

        public override string ToString()
        {
            string fieldErrorsStr = string.Join(", ", FieldErrors.Select(fe => fe.ToString()).ToArray());
            return $"ApiError(error_type='{ErrorType}', error_code='{ErrorCode}', detail='{Detail}', " +
                   $"docs_url='{DocsUrl}', field_errors={fieldErrorsStr})";
        }

        public static ApiError FromErrorData(HttpResponseMessage response, JsonElement error)
        {
            List<FieldError> fieldErrors = new();

            if (error.TryGetProperty("errors", out JsonElement errorsElement) &&
                errorsElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement errorItem in errorsElement.EnumerateArray())
                {
                    if (errorItem.TryGetProperty("field", out JsonElement fieldElement) &&
                        errorItem.TryGetProperty("message", out JsonElement messageElement))
                    {
                        fieldErrors.Add(new FieldError(
                            fieldElement.GetString(),
                            messageElement.GetString()
                        ));
                    }
                }
            }

            return new ApiError(
                response,
                error.GetProperty("type").GetString(),
                error.GetProperty("code").GetString(),
                error.GetProperty("detail").GetString(),
                error.GetProperty("documentation_url").GetString(),
                fieldErrors.ToArray());
        }
    }
}