using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Resources.Transactions.Operations
{
    public class GetTransactionInvoice : IHasParameters
    {
        private readonly Disposition? _disposition;

        public GetTransactionInvoice(Disposition? disposition = null)
        {
            _disposition = disposition;
        }

        public IDictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new();

            if (_disposition.HasValue)
            {
                parameters.Add("disposition", _disposition.ToString().ToLower());
            }

            return parameters;
        }
    }
}