using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Shared.Operations.List;
using PaddleWrapper.Resources.Transactions.Operations.List;

namespace PaddleWrapper.Resources.Transactions.Operations
{
    public class ListTransactions : IHasParameters
    {
        private readonly Pager _pager;
        private readonly DateComparison _billedAt;
        private readonly CollectionMode? _collectionMode;
        private readonly DateComparison _createdAt;
        private readonly string[] _customerIds;
        private readonly string[] _ids;
        private readonly Includes[] _includes;
        private readonly string[] _invoiceNumbers;
        private readonly TransactionStatus[] _statuses;
        private readonly string[] _subscriptionIds;
        private readonly DateComparison _updatedAt;
        private readonly Origin[] _origins;

        public ListTransactions(
            Pager pager = null,
            DateComparison billedAt = null,
            CollectionMode? collectionMode = null,
            DateComparison createdAt = null,
            string[] customerIds = null,
            string[] ids = null,
            Includes[] includes = null,
            string[] invoiceNumbers = null,
            TransactionStatus[] statuses = null,
            string[] subscriptionIds = null,
            DateComparison updatedAt = null,
            Origin[] origins = null)
        {
            _pager = pager;
            _billedAt = billedAt;
            _collectionMode = collectionMode;
            _createdAt = createdAt;
            _customerIds = customerIds ?? new string[0];
            _ids = ids ?? new string[0];
            _includes = includes ?? new Includes[0];
            _invoiceNumbers = invoiceNumbers ?? new string[0];
            _statuses = statuses ?? new TransactionStatus[0];
            _subscriptionIds = subscriptionIds ?? new string[0];
            _updatedAt = updatedAt;
            _origins = origins ?? new Origin[0];
        }

        public IDictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = _pager?.GetParameters() ?? new Dictionary<string, object>();

            if (_billedAt != null)
            {
                parameters.Add($"billed_at{_billedAt.GetComparatorString()}", _billedAt.GetFormattedDate());
            }

            if (_collectionMode.HasValue)
            {
                parameters.Add("collection_mode", _collectionMode.ToString().ToLower());
            }

            if (_createdAt != null)
            {
                parameters.Add($"created_at{_createdAt.GetComparatorString()}", _createdAt.GetFormattedDate());
            }

            if (_customerIds.Any())
            {
                parameters.Add("customer_id", string.Join(",", _customerIds));
            }

            if (_ids.Any())
            {
                parameters.Add("id", string.Join(",", _ids));
            }

            if (_includes.Any())
            {
                parameters.Add("include", string.Join(",", _includes.Select(x => x.ToString().ToLower())));
            }

            if (_invoiceNumbers.Any())
            {
                parameters.Add("invoice_number", string.Join(",", _invoiceNumbers));
            }

            if (_statuses.Any())
            {
                parameters.Add("status", string.Join(",", _statuses.Select(x => x.ToString().ToLower())));
            }

            if (_subscriptionIds.Any())
            {
                parameters.Add("subscription_id", string.Join(",", _subscriptionIds));
            }

            if (_updatedAt != null)
            {
                parameters.Add($"updated_at{_updatedAt.GetComparatorString()}", _updatedAt.GetFormattedDate());
            }

            if (_origins.Any())
            {
                parameters.Add("origin", string.Join(",", _origins.Select(x => x.ToString().ToLower())));
            }

            return parameters;
        }
    }
}