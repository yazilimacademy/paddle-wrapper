using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class DiscountCollection : Collection<Discount>
    {
        private DiscountCollection(List<Discount> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static DiscountCollection FromJson(JsonElement json, Paginator? paginator)
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
                    List<Discount> items = new();
                    foreach (JsonElement item in json.EnumerateArray())
                    {
                        items.Add(Discount.FromJson(item));
                    }
                    return new DiscountCollection(items, paginator);
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

                    List<Discount> items = new();
                    foreach (JsonElement item in dataElement.EnumerateArray())
                    {
                        items.Add(Discount.FromJson(item));
                    }
                    return new DiscountCollection(items, paginator);
                }

                throw new JsonException($"Unexpected JSON type: {json.ValueKind}. Expected Object or Array.");
            }
            catch (JsonException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new JsonException($"Failed to parse discount collection: {ex.Message}", ex);
            }
        }

        public static new DiscountCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var json = JsonSerializer.SerializeToElement(data);
            return FromJson(json, paginator);
        }
    }
}