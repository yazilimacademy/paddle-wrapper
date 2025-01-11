using System;
using System.Text.Json;

namespace PaddleWrapper.Exceptions.SdkExceptions
{
    public class MalformedResponse : SdkException
    {
        public JsonException JsonException { get; }

        public MalformedResponse(JsonException exception)
            : base(exception.Message, exception)
        {
            JsonException = exception;
        }
    }
} 