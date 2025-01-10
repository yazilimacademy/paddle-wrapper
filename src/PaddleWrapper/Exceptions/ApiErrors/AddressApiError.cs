namespace PaddleWrapper.Exceptions.ApiErrors
{
    public class AddressApiError : ApiError
    {
        public AddressApiError(HttpResponseMessage response, string errorType, string errorCode, string detail, string docsUrl, params FieldError[] fieldErrors)
            : base(response, errorType, errorCode, detail, docsUrl, fieldErrors)
        {
        }
    }
}