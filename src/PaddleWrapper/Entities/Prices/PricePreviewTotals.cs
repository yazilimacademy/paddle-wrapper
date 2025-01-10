using System.Text.Json;

namespace PaddleWrapper.Entities.Prices
{
    public class PricePreviewTotals
    {
        public string Subtotal { get; }
        public string Discount { get; }
        public string Tax { get; }
        public string Total { get; }
        public string CurrencyCode { get; }

        public PricePreviewTotals(
            string subtotal,
            string discount,
            string tax,
            string total,
            string currencyCode)
        {
            Subtotal = subtotal;
            Discount = discount;
            Tax = tax;
            Total = total;
            CurrencyCode = currencyCode;
        }

        public static PricePreviewTotals FromDict(JsonElement data)
        {
            return new PricePreviewTotals(
                subtotal: data.GetProperty("subtotal").GetString(),
                discount: data.GetProperty("discount").GetString(),
                tax: data.GetProperty("tax").GetString(),
                total: data.GetProperty("total").GetString(),
                currencyCode: data.GetProperty("currency_code").GetString()
            );
        }
    }
} 