namespace PaddleWrapper.Logger
{
    public sealed class Formatter : IFormatter
    {
        public string FormatRequest(HttpRequestMessage request)
        {
            string transactionId = request.Headers.Contains("X-Transaction-ID")
                ? request.Headers.GetValues("X-Transaction-ID").FirstOrDefault()
                : "-";

            return string.Format("{0} {1} HTTP/{2} {3}",
                request.Method,
                request.RequestUri,
                request.Version,
                transactionId);
        }

        public string FormatResponse(HttpResponseMessage response)
        {
            return string.Format("{0} {1} HTTP/{2} -",
                (int)response.StatusCode,
                response.ReasonPhrase,
                response.Version);
        }

        public string FormatResponseForRequest(HttpResponseMessage response, HttpRequestMessage request)
        {
            string transactionId = request.Headers.Contains("X-Transaction-ID")
                ? request.Headers.GetValues("X-Transaction-ID").FirstOrDefault()
                : "-";

            return string.Format("{0} {1} HTTP/{2} {3}",
                (int)response.StatusCode,
                response.ReasonPhrase,
                response.Version,
                transactionId);
        }
    }
}