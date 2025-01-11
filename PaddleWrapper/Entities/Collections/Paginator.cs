using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;

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
            var response = await _client.GetAsync(_pagination.Next);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
                throw ApiError.FromErrorData(error!);
            }

            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
            var method = _collectionType.GetMethod("From");
            
            var pagination = new Paginator(
                _client,
                Pagination.From((Dictionary<string, object>)data["meta"]),
                _collectionType
            );

            return method!.Invoke(null, new object[] { data, pagination })!;
        }
    }
} 