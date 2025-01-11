using System.Collections.Generic;

namespace PaddleWrapper.Exceptions.ApiErrors
{
    public class ProductApiError : ApiError
    {
        public ProductApiError(
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