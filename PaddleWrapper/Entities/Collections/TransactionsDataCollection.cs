using System.Collections.Generic;
using PaddleWrapper.Entities.Transaction;

namespace PaddleWrapper.Entities.Collections
{
    public class TransactionsDataCollection : Collection<TransactionData>
    {
        private TransactionsDataCollection(List<TransactionData> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new TransactionsDataCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<TransactionData>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(TransactionData.From((Dictionary<string, object>)item));
            }

            return new TransactionsDataCollection(items, paginator);
        }
    }
} 