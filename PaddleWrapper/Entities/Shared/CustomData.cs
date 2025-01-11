using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class CustomData
    {
        private readonly object _data;

        [JsonConstructor]
        public CustomData(object data)
        {
            _data = data;
        }

        public JsonElement ToJsonElement()
        {
            if (_data is Dictionary<string, object> dict && dict.Count == 0)
            {
                return JsonSerializer.SerializeToElement(new { });
            }

            return JsonSerializer.SerializeToElement(_data);
        }

        public static CustomData From(Dictionary<string, object> data)
        {
            return new CustomData(data);
        }
    }
} 