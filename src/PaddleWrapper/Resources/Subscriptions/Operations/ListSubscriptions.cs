using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Entities.Subscriptions;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Subscriptions.Operations
{
    public class ListSubscriptions : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly string[] _addressIds;
        private readonly CollectionMode? _collectionMode;
        private readonly string[] _customerIds;
        private readonly string[] _ids;
        private readonly string[] _priceIds;
        private readonly SubscriptionScheduledChangeAction[] _scheduledChangeActions;
        private readonly SubscriptionStatus[] _statuses;

        public ListSubscriptions(
            Pager? pager = null,
            string[]? addressIds = null,
            CollectionMode? collectionMode = null,
            string[]? customerIds = null,
            string[]? ids = null,
            string[]? priceIds = null,
            SubscriptionScheduledChangeAction[]? scheduledChangeActions = null,
            SubscriptionStatus[]? statuses = null)
        {
            _pager = pager;
            _addressIds = addressIds ?? Array.Empty<string>();
            _collectionMode = collectionMode;
            _customerIds = customerIds ?? Array.Empty<string>();
            _ids = ids ?? Array.Empty<string>();
            _priceIds = priceIds ?? Array.Empty<string>();
            _scheduledChangeActions = scheduledChangeActions ?? Array.Empty<SubscriptionScheduledChangeAction>();
            _statuses = statuses ?? Array.Empty<SubscriptionStatus>();
        }

        public IDictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new();

            if (_pager != null)
            {
                foreach (KeyValuePair<string, object> param in _pager.GetParameters())
                {
                    parameters[param.Key] = param.Value;
                }
            }

            if (_addressIds.Any())
            {
                parameters["address_id"] = string.Join(",", _addressIds);
            }

            if (_collectionMode.HasValue)
            {
                parameters["collection_mode"] = _collectionMode.ToString().ToLower();
            }

            if (_customerIds.Any())
            {
                parameters["customer_id"] = string.Join(",", _customerIds);
            }

            if (_ids.Any())
            {
                parameters["id"] = string.Join(",", _ids);
            }

            if (_priceIds.Any())
            {
                parameters["price_id"] = string.Join(",", _priceIds);
            }

            if (_scheduledChangeActions.Any())
            {
                parameters["scheduled_change_action"] = string.Join(",", _scheduledChangeActions.Select(s => s.ToString().ToLower()));
            }

            if (_statuses.Any())
            {
                parameters["status"] = string.Join(",", _statuses.Select(s => s.ToString().ToLower()));
            }

            return parameters;
        }
    }
}