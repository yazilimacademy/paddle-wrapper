using System.Text.Json;
using PaddleWrapper.Entities.Transactions;

namespace PaddleWrapper.Entities.Collections
{
    public class TransactionPreviewCollection : Collection<TransactionPreview>
    {
        public TransactionPreviewCollection(List<TransactionPreview> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static TransactionPreviewCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(TransactionPreview.FromDict).ToList();
            return new TransactionPreviewCollection(items, paginator);
        }
    }
} 