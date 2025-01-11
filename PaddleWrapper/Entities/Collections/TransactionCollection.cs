using System.Collections.Generic;
using PaddleWrapper.Entities.Transaction;

namespace PaddleWrapper.Entities.Collections
{
    public class TransactionCollection : Collection<Transaction.Transaction>
    {
        private TransactionCollection(List<Transaction.Transaction> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new TransactionCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Transaction.Transaction>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Transaction.Transaction.From((Dictionary<string, object>)item));
            }

            return new TransactionCollection(items, paginator);
        }
    }
} 