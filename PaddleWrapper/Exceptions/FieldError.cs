namespace PaddleWrapper.Exceptions
{
    public class FieldError
    {
        public string Field { get; }
        public string Error { get; }

        public FieldError(string field, string error)
        {
            Field = field;
            Error = error;
        }
    }
}