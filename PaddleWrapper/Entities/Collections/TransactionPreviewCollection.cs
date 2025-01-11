using System.Collections.Generic;
using PaddleWrapper.Entities.Transaction;

namespace PaddleWrapper.Entities.Collections
{
    public class TransactionPreviewCollection : Collection<TransactionPreview>
    {
        private TransactionPreviewCollection(List<TransactionPreview> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new TransactionPreviewCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<TransactionPreview>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(TransactionPreview.From((Dictionary<string, object>)item));
            }

            return new TransactionPreviewCollection(items, paginator);
        }
    }
} 