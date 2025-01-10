using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public class Paginator
    {
        public int PerPage { get; }
        public string Next { get; }
        public string Previous { get; }
        public string Order { get; }

        public Paginator(
            int perPage,
            string next,
            string previous,
            string order)
        {
            PerPage = perPage;
            Next = next;
            Previous = previous;
            Order = order;
        }

        public static Paginator FromDict(JsonElement data)
        {
            return new Paginator(
                perPage: data.GetProperty("per_page").GetInt32(),
                next: data.TryGetProperty("next", out var next) ? next.GetString() : null,
                previous: data.TryGetProperty("previous", out var previous) ? previous.GetString() : null,
                order: data.GetProperty("order").GetString()
            );
        }
    }
} 