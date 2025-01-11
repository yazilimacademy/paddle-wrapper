using System;

namespace PaddleWrapper.Exceptions
{
    public class SdkException : Exception
    {
        public SdkException() { }
        public SdkException(string message) : base(message) { }
        public SdkException(string message, Exception inner) : base(message, inner) { }
    }
} 