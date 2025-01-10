using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class InvoiceCollection : Collection<Invoice>
    {
        public InvoiceCollection(List<Invoice> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static InvoiceCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Invoice.FromDict).ToList();
            return new InvoiceCollection(items, paginator);
        }
    }
} 