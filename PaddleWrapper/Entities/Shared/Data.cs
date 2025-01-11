using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Data
    {
        private readonly object _data;

        [JsonConstructor]
        public Data(object data)
        {
            _data = data;
        }

        public static Data From(Dictionary<string, object> data)
        {
            return new Data(data);
        }
    }
} 