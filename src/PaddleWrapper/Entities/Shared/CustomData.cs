using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public class CustomData
    {
        public JsonElement Data { get; }

        public CustomData(JsonElement data)
        {
            Data = data;
        }
    }
} 