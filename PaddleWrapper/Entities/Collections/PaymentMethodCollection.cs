namespace PaddleWrapper.Entities.Collections
{
    public class PaymentMethodCollection : Collection<PaymentMethod>
    {
        private PaymentMethodCollection(List<PaymentMethod> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new PaymentMethodCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<PaymentMethod> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(PaymentMethod.From((Dictionary<string, object>)item));
            }

            return new PaymentMethodCollection(items, paginator);
        }
    }
}