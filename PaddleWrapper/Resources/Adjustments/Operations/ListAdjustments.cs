using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Shared.Operations.List;
using Action = PaddleWrapper.Entities.Shared.Action;

namespace PaddleWrapper.Resources.Adjustments.Operations
{
    public class ListAdjustments : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly List<string> _ids;
        private readonly List<AdjustmentStatus> _statuses;
        private readonly List<string> _customerIds;
        private readonly List<string> _transactionIds;
        private readonly List<string> _subscriptionIds;
        private readonly Action? _action;

        public ListAdjustments(
            Pager? pager = null,
            IEnumerable<string>? ids = null,
            IEnumerable<AdjustmentStatus>? statuses = null,
            IEnumerable<string>? customerIds = null,
            IEnumerable<string>? transactionIds = null,
            IEnumerable<string>? subscriptionIds = null,
            Action? action = null)
        {
            _pager = pager;
            _ids = ids?.ToList() ?? new List<string>();
            _statuses = statuses?.ToList() ?? new List<AdjustmentStatus>();
            _customerIds = customerIds?.ToList() ?? new List<string>();
            _transactionIds = transactionIds?.ToList() ?? new List<string>();
            _subscriptionIds = subscriptionIds?.ToList() ?? new List<string>();
            _action = action;

            ValidateIds(_ids, "ids");
            ValidateIds(_customerIds, "customerIds");
            ValidateIds(_transactionIds, "transactionIds");
            ValidateIds(_subscriptionIds, "subscriptionIds");
        }

        private void ValidateIds(List<string> ids, string paramName)
        {
            if (ids.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException($"{paramName} cannot contain null or empty values", paramName);
            }
        }

        public IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (_pager != null)
            {
                foreach (var param in _pager.GetParameters())
                {
                    parameters[param.Key] = param.Value;
                }
            }

            if (_ids.Any())
            {
                parameters["id"] = string.Join(",", _ids);
            }

            if (_statuses.Any())
            {
                parameters["status"] = string.Join(",", _statuses);
            }

            if (_customerIds.Any())
            {
                parameters["customer_id"] = string.Join(",", _customerIds);
            }

            if (_transactionIds.Any())
            {
                parameters["transaction_id"] = string.Join(",", _transactionIds);
            }

            if (_subscriptionIds.Any())
            {
                parameters["subscription_id"] = string.Join(",", _subscriptionIds);
            }

            if (_action != null)
            {
                parameters["action"] = _action;
            }

            return parameters;
        }
    }
}