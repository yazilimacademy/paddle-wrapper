using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class Paginator
    {
        private readonly HttpClient _client;
        private readonly Pagination _pagination;
        private readonly Type _collectionType;

        public Paginator(HttpClient client, Pagination pagination, Type collectionType)
        {
            _client = client;
            _pagination = pagination;
            _collectionType = collectionType;
        }

        public bool HasMore()
        {
            return _pagination.HasMore;
        }

        public async Task<object> NextPage()
        {
            HttpResponseMessage response = await _client.Get(_pagination.Next);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Dictionary<string, object>? error = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
                throw ApiError.FromErrorData(error!);
            }

            Dictionary<string, object>? data = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
            System.Reflection.MethodInfo? method = _collectionType.GetMethod("From");

            Paginator pagination = new(
                _client,
                Pagination.From((Dictionary<string, object>)data["meta"]),
                _collectionType
            );

            return method!.Invoke(null, new object[] { data, pagination })!;
        }
    }
}