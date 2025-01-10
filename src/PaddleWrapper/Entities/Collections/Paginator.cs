namespace PaddleWrapper.Entities.Collections
{
    public class Paginator
    {
        private readonly Client _client;
        private readonly Pagination _pagination;
        private readonly ICollectionMapper _mapper;

        public Paginator(Client client, Pagination pagination, ICollectionMapper mapper)
        {
            _client = client;
            _pagination = pagination;
            _mapper = mapper;
        }

        public bool HasMore => _pagination.HasMore;

        public Collection<T> NextPage<T>()
        {
            var response = _client.GetRaw(_pagination.Next);
            var responseParser = new ResponseParser(response);

            return _mapper.FromList<T>(
                responseParser.GetData(),
                new Paginator(_client, responseParser.GetPagination(), _mapper)
            );
        }
    }
} 