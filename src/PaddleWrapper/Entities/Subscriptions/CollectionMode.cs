using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class CollectionMode
    {
        public string Mode { get; }

        public CollectionMode(string mode)
        {
            Mode = mode;
        }

        public static CollectionMode FromDict(JsonElement data)
        {
            return new CollectionMode(data.GetProperty("mode").GetString());
        }
    }
} 