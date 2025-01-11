namespace PaddleWrapper.Exceptions.ApiErrors
{
    public class AddressApiError : ApiError
    {
        public AddressApiError(
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