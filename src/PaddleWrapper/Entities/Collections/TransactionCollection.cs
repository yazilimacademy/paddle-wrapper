using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class TransactionCollection : Collection<Transaction>
    {
        public TransactionCollection(List<Transaction> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static TransactionCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Transaction.FromDict).ToList();
            return new TransactionCollection(items, paginator);
        }
    }
} 