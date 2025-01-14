using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class BusinessCollection : Collection<Business>
    {
        private BusinessCollection(List<Business> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static BusinessCollection FromJson(JsonElement json, Paginator? paginator)
        {
            try
            {
                // Gelen JSON'ın yapısını kontrol et
                if (json.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("JSON response is null");
                }

                // Eğer doğrudan bir array gelirse, onu data array'i olarak kabul et
                if (json.ValueKind == JsonValueKind.Array)
                {
                    List<Business> items = new();
                    foreach (JsonElement item in json.EnumerateArray())
                    {
                        items.Add(Business.FromJson(item));
                    }
                    return new BusinessCollection(items, paginator);
                }

                // Object gelirse, data property'sini kontrol et
                if (json.ValueKind == JsonValueKind.Object)
                {
                    if (!json.TryGetProperty("data", out JsonElement dataElement))
                    {
                        throw new JsonException("Missing 'data' property in JSON response");
                    }

                    if (dataElement.ValueKind != JsonValueKind.Array)
                    {
                        throw new JsonException("'data' property must be an array");
                    }

                    List<Business> items = new();
                    foreach (JsonElement item in dataElement.EnumerateArray())
                    {
                        items.Add(Business.FromJson(item));
                    }
                    return new BusinessCollection(items, paginator);
                }

                throw new JsonException($"Unexpected JSON type: {json.ValueKind}. Expected Object or Array.");
            }
            catch (JsonException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new JsonException($"Failed to parse business collection: {ex.Message}", ex);
            }
        }

        public static new BusinessCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            JsonElement json = JsonSerializer.SerializeToElement(data);
            return FromJson(json, paginator);
        }
    }
}