namespace PaddleWrapper.Logger
{
    public interface IFormatter
    {
        string FormatRequest(HttpRequestMessage request);
        string FormatResponse(HttpResponseMessage response);
        string FormatResponseForRequest(HttpResponseMessage response, HttpRequestMessage request);
    }
}