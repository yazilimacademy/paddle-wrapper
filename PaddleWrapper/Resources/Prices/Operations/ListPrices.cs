using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Prices.Operations.List;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Prices.Operations
{
    public class ListPrices : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly List<Includes> _includes;
        private readonly List<string> _ids;
        private readonly List<CatalogType> _types;
        private readonly List<string> _productIds;
        private readonly List<Status> _statuses;
        private readonly bool? _recurring;

        public ListPrices(
            Pager? pager = null,
            IEnumerable<Includes>? includes = null,
            IEnumerable<string>? ids = null,
            IEnumerable<CatalogType>? types = null,
            IEnumerable<string>? productIds = null,
            IEnumerable<Status>? statuses = null,
            bool? recurring = null)
        {
            _pager = pager;
            _includes = includes?.ToList() ?? new List<Includes>();
            _ids = ids?.ToList() ?? new List<string>();
            _types = types?.ToList() ?? new List<CatalogType>();
            _productIds = productIds?.ToList() ?? new List<string>();
            _statuses = statuses?.ToList() ?? new List<Status>();
            _recurring = recurring;

            ValidateIncludes(_includes);
            ValidateIds(_ids, "ids");
            ValidateTypes(_types);
            ValidateIds(_productIds, "productIds");
            ValidateStatuses(_statuses);
        }

        private void ValidateIncludes(List<Includes> includes)
        {
            if (includes.Any(include => include == null))
            {
                throw new ArgumentException("includes cannot contain null values", nameof(includes));
            }
        }

        private void ValidateIds(List<string> ids, string paramName)
        {
            if (ids.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException($"{paramName} cannot contain null or empty values", paramName);
            }
        }

        private void ValidateTypes(List<CatalogType> types)
        {
            if (types.Any(type => type == null))
            {
                throw new ArgumentException("types cannot contain null values", nameof(types));
            }
        }

        private void ValidateStatuses(List<Status> statuses)
        {
            if (statuses.Any(status => status == null))
            {
                throw new ArgumentException("statuses cannot contain null values", nameof(statuses));
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

            if (_includes.Any())
            {
                parameters["include"] = string.Join(",", _includes.Select(x => x.ToString().ToLower()));
            }

            if (_ids.Any())
            {
                parameters["id"] = string.Join(",", _ids);
            }

            if (_types.Any())
            {
                parameters["type"] = string.Join(",", _types.Select(x => x.ToString().ToLower()));
            }

            if (_productIds.Any())
            {
                parameters["product_id"] = string.Join(",", _productIds);
            }

            if (_statuses.Any())
            {
                parameters["status"] = string.Join(",", _statuses.Select(x => x.ToString().ToLower()));
            }

            if (_recurring.HasValue)
            {
                parameters["recurring"] = _recurring.Value.ToString().ToLowerInvariant();
            }

            return parameters;
        }
    }
}