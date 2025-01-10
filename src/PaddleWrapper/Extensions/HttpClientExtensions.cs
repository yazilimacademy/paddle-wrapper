namespace PaddleWrapper.Extensions
{
#if NETSTANDARD2_0
    internal static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            return client.PatchAsync(requestUri, content, CancellationToken.None);
        }

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            HttpMethod method = new("PATCH");
            HttpRequestMessage request = new(method, requestUri)
            {
                Content = content
            };

            return client.SendAsync(request, cancellationToken);
        }

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content)
        {
            return client.PatchAsync(requestUri, content, CancellationToken.None);
        }

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            HttpMethod method = new("PATCH");
            HttpRequestMessage request = new(method, requestUri)
            {
                Content = content
            };

            return client.SendAsync(request, cancellationToken);
        }
    }
#endif
}