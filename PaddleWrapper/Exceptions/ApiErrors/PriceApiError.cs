namespace PaddleWrapper.Exceptions.ApiErrors
{
    public class PriceApiError : ApiError
    {
        public PriceApiError(
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