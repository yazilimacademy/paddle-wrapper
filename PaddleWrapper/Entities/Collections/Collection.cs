using System.Collections;

namespace PaddleWrapper.Entities.Collections
{
    public abstract class Collection<T> : IEnumerable<T> where T : class
    {
        protected readonly List<T> Items;
        protected readonly Paginator? Paginator;
        private int _pointer = 0;

        protected Collection(List<T> items, Paginator? paginator = null)
        {
            Items = items;
            Paginator = paginator;
        }

        public abstract static Collection<T> From(Dictionary<string, object> data, Paginator? paginator);

        public IEnumerator<T> GetEnumerator()
        {
            while (_pointer < Items.Count || (Paginator?.HasMore() ?? false))
            {
                if (_pointer >= Items.Count)
                {
                    Task<object> nextPage = Paginator!.NextPage();
                    Items.Clear();
                    Items.AddRange(((Collection<T>)nextPage).Items);
                    _pointer = 0;
                }

                yield return Items[_pointer++];
            }

            _pointer = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}