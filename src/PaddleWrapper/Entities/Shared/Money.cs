using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public class Money
    {
        public string Amount { get; }
        public CurrencyCode CurrencyCode { get; }

        public Money(string amount, CurrencyCode currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }
    }
} 