using System.Collections.Generic;

namespace PaddleWrapper.Exceptions.ApiErrors
{
    public class SubscriptionApiError : ApiError
    {
        public SubscriptionApiError(
            string type,
            string errorCode,
            string detail,
            string docsUrl,
            IEnumerable<FieldError> fieldErrors = null)
            : base(type, errorCode, detail, docsUrl, fieldErrors)
        {
        }
    }
} 