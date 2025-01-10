using System.Text.Json;

namespace PaddleWrapper.Entities.Invoices
{
    public class TaxRatesUsed
    {
        public string TaxRate { get; }
        public InvoiceTotals Totals { get; }

        public TaxRatesUsed(string taxRate, InvoiceTotals totals)
        {
            TaxRate = taxRate;
            Totals = totals;
        }

        public static TaxRatesUsed FromDict(JsonElement data)
        {
            return new TaxRatesUsed(
                taxRate: data.GetProperty("tax_rate").GetString(),
                totals: InvoiceTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 