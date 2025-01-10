using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class PaymentMethodCollection : Collection<PaymentMethod>
    {
        public PaymentMethodCollection(List<PaymentMethod> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static PaymentMethodCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(PaymentMethod.FromDict).ToList();
            return new PaymentMethodCollection(items, paginator);
        }
    }
} 