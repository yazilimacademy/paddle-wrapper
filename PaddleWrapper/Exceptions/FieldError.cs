namespace PaddleWrapper.Exceptions
{
    public class FieldError
    {
        public string Field { get; }
        public string Code { get; }
        public string Message { get; }

        public FieldError(string field, string code, string message)
        {
            Field = field;
            Code = code;
            Message = message;
        }
    }
}