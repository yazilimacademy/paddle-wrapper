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
            List<TransactionData> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(TransactionData.From((Dictionary<string, object>)item));
            }

            return new TransactionsDataCollection(items, paginator);
        }
    }
}