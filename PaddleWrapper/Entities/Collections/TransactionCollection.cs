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
            List<Transaction.Transaction> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Transaction.Transaction.From((Dictionary<string, object>)item));
            }

            return new TransactionCollection(items, paginator);
        }
    }
}