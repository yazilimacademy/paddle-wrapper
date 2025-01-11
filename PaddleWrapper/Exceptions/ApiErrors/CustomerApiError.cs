namespace PaddleWrapper.Exceptions.ApiErrors
{
    public class CustomerApiError : ApiError
    {
        public CustomerApiError(
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