using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class AddressCollection : Collection<Address>
    {
        public AddressCollection(IEnumerable<Address> items, Paginator? paginator = null) : base(items, paginator)
        {
        }

        public static AddressCollection FromJson(JsonElement json, Paginator? paginator = null)
        {
            if (json.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Expected JSON array but got {json.ValueKind}");
            }

            List<Address> addresses = new();
            foreach (JsonElement element in json.EnumerateArray())
            {
                addresses.Add(Address.FromJson(element));
            }

            return new AddressCollection(addresses, paginator);
        }

        public static AddressCollection From(Dictionary<string, object> data, Paginator? paginator = null)
        {
            if (!data.ContainsKey("data"))
            {
                throw new InvalidOperationException("Data dictionary does not contain 'data' key");
            }

            JsonElement json = JsonSerializer.SerializeToElement(data["data"]);
            return FromJson(json, paginator);
        }
    }
}