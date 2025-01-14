namespace PaddleWrapper.Exceptions.SdkExceptions
{
    public class MalformedResponse : SdkException
    {
        public MalformedResponse(string message) : base(message)
        {
        }

        public MalformedResponse(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}