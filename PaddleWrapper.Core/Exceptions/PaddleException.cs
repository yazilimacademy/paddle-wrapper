namespace PaddleWrapper.Core.Exceptions
{
    public class PaddleException : Exception
    {
        public int? ErrorCode { get; }
        public string ErrorType { get; }

        public PaddleException(string message) : base(message)
        {
        }

        public PaddleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PaddleException(string message, int errorCode, string errorType) : base(message)
        {
            ErrorCode = errorCode;
            ErrorType = errorType;
        }
    }

    public class PaddleAuthenticationException : PaddleException
    {
        public PaddleAuthenticationException(string message) : base(message)
        {
        }
    }

    public class PaddleValidationException : PaddleException
    {
        public PaddleValidationException(string message) : base(message)
        {
        }
    }

    public class PaddleWebhookException : PaddleException
    {
        public PaddleWebhookException(string message) : base(message)
        {
        }

        public PaddleWebhookException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class PaddleApiException : PaddleException
    {
        public PaddleApiException(string message, int errorCode, string errorType)
            : base(message, errorCode, errorType)
        {
        }
    }
}