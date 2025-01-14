namespace PaddleWrapper.Exceptions.SdkExceptions
{
    public class InvalidArgumentException : SdkException
    {
        public static InvalidArgumentException ArrayIsEmpty(string field)
        {
            return new InvalidArgumentException($"{field} cannot be empty");
        }

        public static InvalidArgumentException ArrayContainsInvalidTypes(string field, string expectedType, string given)
        {
            return new InvalidArgumentException(
                $"expected {field} to only contain only type/s {expectedType}, {given} given");
        }

        public InvalidArgumentException(string message) : base(message) { }
        public InvalidArgumentException(string message, Exception inner) : base(message, inner) { }
    }
}