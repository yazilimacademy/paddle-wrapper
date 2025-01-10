namespace PaddleWrapper.Entities.Shared
{
    public class Pagination
    {
        public int PerPage { get; }
        public string Next { get; }
        public bool HasMore { get; }
        public string Order { get; }

        public Pagination(int perPage, string next, bool hasMore, string order)
        {
            PerPage = perPage;
            Next = next;
            HasMore = hasMore;
            Order = order;
        }

        public static Pagination FromDict(JsonElement data)
        {
            return new Pagination(
                data.GetProperty("per_page").GetInt32(),
                data.GetProperty("next").GetString(),
                data.GetProperty("has_more").GetBoolean(),
                data.GetProperty("order").GetString()
            );
        }
    }
} 