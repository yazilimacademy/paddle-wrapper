using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Resources.Customers.Operations
{
    public class ListCreditBalances : IHasParameters
    {
        private readonly List<CurrencyCode> _currencyCodes;

        public ListCreditBalances(IEnumerable<CurrencyCode>? currencyCodes = null)
        {
            _currencyCodes = currencyCodes?.ToList() ?? new List<CurrencyCode>();
        }

        public IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (_currencyCodes.Any())
            {
                parameters["currency_code"] = string.Join(",", _currencyCodes);
            }

            return parameters;
        }
    }
}