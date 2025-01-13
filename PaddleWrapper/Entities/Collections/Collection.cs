namespace PaddleWrapper.Entities.Collections
{
    public abstract class Collection<T> : IEnumerable<T>
    {
        private readonly List<T> _items;
        private readonly Paginator? _paginator;

        protected Collection(IEnumerable<T> items, Paginator? paginator = null)
        {
            _items = items.ToList();
            _paginator = paginator;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count()
        {
            return _items.Count;
        }
    }
}