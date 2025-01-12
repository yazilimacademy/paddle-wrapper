namespace PaddleWrapper.Resources.Shared.Operations.List
{
    public class Pager : IHasParameters
    {
        private readonly string? _after;
        private readonly OrderBy _orderBy;
        private readonly int _perPage;

        public Pager(string? after = null, OrderBy? orderBy = null, int perPage = 50)
        {
            _after = after;
            _orderBy = orderBy ?? OrderBy.IdAscending();
            _perPage = perPage;
        }

        public Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object>
            {
                { "after", _after },
                { "order_by", _orderBy.ToString() },
                { "per_page", _perPage }
            }.Where(kvp => kvp.Value != null).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }

    public interface IHasParameters
    {
        /// <summary>
        /// Parametreleri döndürür
        /// </summary>
        Dictionary<string, object> GetParameters();
    }
}