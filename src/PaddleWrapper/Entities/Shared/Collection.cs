using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public abstract class Collection<T>
    {
        public List<T> Items { get; }
        public Paginator Paginator { get; }

        protected Collection(List<T> items, Paginator paginator = null)
        {
            Items = items;
            Paginator = paginator;
        }
    }
} 