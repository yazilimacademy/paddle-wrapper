using System;
using System.Collections.Generic;
using System.Linq;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.PaymentMethods.Operations
{
    public class ListPaymentMethods : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly List<string> _addressIds;
        private readonly bool? _supportsCheckout;

        public ListPaymentMethods(
            Pager? pager = null,
            IEnumerable<string>? addressIds = null,
            bool? supportsCheckout = null)
        {
            _pager = pager;
            _addressIds = addressIds?.ToList() ?? new List<string>();
            _supportsCheckout = supportsCheckout;

            ValidateIds(_addressIds, "addressIds");
        }

        private void ValidateIds(List<string> ids, string paramName)
        {
            if (ids.Any(id => string.IsNullOrEmpty(id)))
            {
                throw new ArgumentException($"{paramName} cannot contain null or empty values", paramName);
            }
        }

        public Dictionary<string, object> GetParameters()
        {
            var parameters = _pager?.GetParameters() ?? new Dictionary<string, object>();

            if (_addressIds.Any())
            {
                parameters["address_id"] = string.Join(",", _addressIds);
            }

            if (_supportsCheckout.HasValue)
            {
                parameters["supports_checkout"] = _supportsCheckout.Value.ToString().ToLowerInvariant();
            }

            return parameters;
        }
    }
} 