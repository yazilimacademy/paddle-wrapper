using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Invoices
{
    public class InvoiceItem
    {
        public string PriceId { get; }
        public string Quantity { get; }
        public Proration Proration { get; }
        public InvoiceItemTotals Totals { get; }

        public InvoiceItem(
            string priceId,
            string quantity,
            Proration proration,
            InvoiceItemTotals totals)
        {
            PriceId = priceId;
            Quantity = quantity;
            Proration = proration;
            Totals = totals;
        }

        public static InvoiceItem FromDict(JsonElement data)
        {
            return new InvoiceItem(
                priceId: data.GetProperty("price_id").GetString(),
                quantity: data.GetProperty("quantity").GetString(),
                proration: data.TryGetProperty("proration", out var proration) ? 
                    Proration.FromDict(proration) : null,
                totals: InvoiceItemTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 