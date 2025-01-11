namespace PaddleWrapper.Http;

public interface IHttpRequest
{
    IDictionary<string, IList<string>> Headers { get; }
    Stream Body { get; }
} 