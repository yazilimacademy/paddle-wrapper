using System.Text.Json;

namespace PaddleWrapper.Entities.Invoices
{
    public class InvoiceDetails
    {
        public TaxRatesUsed[] TaxRatesUsed { get; }
        public InvoiceTotals Totals { get; }

        public InvoiceDetails(TaxRatesUsed[] taxRatesUsed, InvoiceTotals totals)
        {
            TaxRatesUsed = taxRatesUsed;
            Totals = totals;
        }

        public static InvoiceDetails FromDict(JsonElement data)
        {
            var taxRatesUsed = data.GetProperty("tax_rates_used").EnumerateArray()
                .Select(TaxRatesUsed.FromDict)
                .ToArray();

            return new InvoiceDetails(
                taxRatesUsed: taxRatesUsed,
                totals: InvoiceTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 