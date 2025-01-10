using System;
using System.Net;

namespace PaddleWrapper.Exceptions
{
    /// <summary>
    /// Represents errors that occur during Paddle API operations
    /// </summary>
    public class PaddleException : Exception
    {
        /// <summary>
        /// The HTTP status code returned by the API
        /// </summary>
        public HttpStatusCode? StatusCode { get; }

        /// <summary>
        /// The error code returned by the API
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// The request ID returned by the API for tracking purposes
        /// </summary>
        public string RequestId { get; }

        /// <summary>
        /// Creates a new instance of PaddleException
        /// </summary>
        public PaddleException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of PaddleException with status code
        /// </summary>
        public PaddleException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Creates a new instance of PaddleException with status code and error details
        /// </summary>
        public PaddleException(string message, HttpStatusCode statusCode, string errorCode, string requestId)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            RequestId = requestId;
        }

        /// <summary>
        /// Creates a new instance of PaddleException with inner exception
        /// </summary>
        public PaddleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}