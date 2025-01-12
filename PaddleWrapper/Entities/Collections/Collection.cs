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

        public static Collection<T> From(Dictionary<string, object> data, Paginator? paginator)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (_pointer < Items.Count || (Paginator?.HasMore() ?? false))
            {
                if (_pointer >= Items.Count)
                {
                    var nextPageTask = Paginator!.NextPage();
                    nextPageTask.Wait(); // Task'i bekle
                    var nextPage = nextPageTask.Result as Collection<T>;
                    if (nextPage == null)
                    {
                        throw new InvalidOperationException("NextPage returned invalid collection type");
                    }

                    Items.Clear();
                    Items.AddRange(nextPage.Items);
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