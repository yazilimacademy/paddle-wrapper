using Newtonsoft.Json;
using System.Net;

namespace PaddleWrapper.Tests
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly object _response;
        private readonly HttpStatusCode _statusCode;

        public MockHttpMessageHandler(object response, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            _response = response;
            _statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new(_statusCode)
            {
                Content = new StringContent(JsonConvert.SerializeObject(_response))
            };

            return Task.FromResult(response);
        }
    }
}