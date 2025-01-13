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
            HttpResponseMessage response = await _client.GetAsync(_pagination.Next);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                JsonElement jsonError = JsonDocument.Parse(content).RootElement;
                throw ApiError.FromErrorJson(jsonError);
            }

            JsonElement jsonElement = JsonDocument.Parse(content).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator pagination = new(
                _client,
                Pagination.FromJson(meta),
                _collectionType
            );

            System.Reflection.MethodInfo? fromJsonMethod = _collectionType.GetMethod("FromJson", new[] { typeof(JsonElement) });
            if (fromJsonMethod == null)
            {
                throw new InvalidOperationException($"Type {_collectionType.Name} does not have a FromJson method");
            }

            return fromJsonMethod.Invoke(null, new object[] { data })!;
        }
    }
}