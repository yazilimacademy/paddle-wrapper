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
            List<TransactionPreview> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(TransactionPreview.From((Dictionary<string, object>)item));
            }

            return new TransactionPreviewCollection(items, paginator);
        }
    }
}