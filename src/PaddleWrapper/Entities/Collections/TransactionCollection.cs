using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class TransactionCollection : Collection<Transaction>
    {
        private TransactionCollection(List<Transaction> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static TransactionCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new TransactionCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Transaction> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Transaction.From((Dictionary<string, object>)item));
            }

            return new TransactionCollection(items, paginator);
        }
    }
}