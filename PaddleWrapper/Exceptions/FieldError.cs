using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Exceptions
{
    public class FieldError
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        public FieldError(string field, string code, string message)
        {
            Code = code;
            Field = field;
            Message = message;
        }

        public static FieldError FromJson(JsonElement element)
        {
            return new FieldError
            (
                element.GetProperty("field").GetString() ?? string.Empty,
                element.GetProperty("message").GetString() ?? string.Empty,
                element.GetProperty("code").GetString() ?? string.Empty);
        }
    }
}