using System.Text.Json;

namespace PaddleWrapper.Exceptions.ApiErrors
{
    public class BusinessApiError : ApiError
    {
        public BusinessApiError(
            string type,
            string code,
            string detail,
            string documentationUrl,
            List<FieldError> fieldErrors = null)
            : base(type, code, detail, documentationUrl, fieldErrors)
        {
        }

        public static new BusinessApiError FromJson(JsonElement json)
        {
            JsonElement error = json.GetProperty("error");
            return new BusinessApiError(
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