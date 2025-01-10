using System.Collections;

namespace PaddleWrapper.Entities.Collections
{
    public abstract class Collection<T> : IEnumerable<T>
    {
        protected readonly List<T> Items;
        protected readonly Paginator Paginator;
        private int _pointer;

        protected Collection(List<T> items, Paginator paginator = null)
        {
            Items = items;
            Paginator = paginator;
            _pointer = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            _pointer = 0;
            return new CollectionEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Current => Items[_pointer];

        public string Key => Items[_pointer] is IEntity entity ? entity.Id : _pointer.ToString();

        private class CollectionEnumerator<TItem> : IEnumerator<TItem>
        {
            private readonly Collection<TItem> _collection;
            private int _position = -1;

            public CollectionEnumerator(Collection<TItem> collection)
            {
                _collection = collection;
            }

            public bool MoveNext()
            {
                _position++;
                if (_position < _collection.Items.Count)
                {
                    return true;
                }

                if (_collection.Paginator?.HasMore == true)
                {
                    var newCollection = _collection.Paginator.NextPage();
                    _collection.Items.AddRange(newCollection.Items);
                    return _position < _collection.Items.Count;
                }

                return false;
            }

            public void Reset()
            {
                _position = -1;
            }

            public TItem Current => _collection.Items[_position];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                // No resources to dispose
            }
        }
    }
} 