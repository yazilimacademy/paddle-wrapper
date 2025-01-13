using System.Text.Json;

namespace PaddleWrapper.Exceptions
{
    public class ApiError : SdkException
    {
        public string Type { get; }
        public string ErrorCode { get; }
        public string Detail { get; }
        public string DocsUrl { get; }
        public IReadOnlyList<FieldError> FieldErrors { get; }

        public ApiError(
            string type,
            string errorCode,
            string detail,
            string docsUrl,
            IEnumerable<FieldError> fieldErrors = null) : base(detail)
        {
            Type = type;
            ErrorCode = errorCode;
            Detail = detail;
            DocsUrl = docsUrl;
            FieldErrors = fieldErrors?.ToList().AsReadOnly() ?? new List<FieldError>().AsReadOnly();
        }

        public static ApiError FromErrorJson(JsonElement json)
        {
            return FromErrorData(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()));
        }

        public static ApiError FromErrorData(IDictionary<string, object> error)
        {
            IEnumerable<FieldError> fieldErrors = error.ContainsKey("errors")
                ? ((IEnumerable<IDictionary<string, object>>)error["errors"])
                    .Select(fe => new FieldError(
                        fe["field"].ToString(),
                        fe["message"].ToString()))
                : Enumerable.Empty<FieldError>();

            return new ApiError(
                error["type"].ToString(),
                error["code"].ToString(),
                error["detail"].ToString(),
                error["documentation_url"].ToString(),
                fieldErrors);
        }
    }
}