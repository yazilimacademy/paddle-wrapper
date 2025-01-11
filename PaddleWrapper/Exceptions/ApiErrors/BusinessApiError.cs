using System.Collections.Generic;

namespace PaddleWrapper.Exceptions.ApiErrors
{
    public class BusinessApiError : ApiError
    {
        public BusinessApiError(
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