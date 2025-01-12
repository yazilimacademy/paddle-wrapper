using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Products.Operations.List;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Products.Operations
{
    public class ListProducts : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly List<Includes> _includes;
        private readonly List<string> _ids;
        private readonly List<CatalogType> _types;
        private readonly List<Status> _statuses;
        private readonly List<TaxCategory> _taxCategories;

        public ListProducts(
            Pager? pager = null,
            IEnumerable<Includes>? includes = null,
            IEnumerable<string>? ids = null,
            IEnumerable<CatalogType>? types = null,
            IEnumerable<Status>? statuses = null,
            IEnumerable<TaxCategory>? taxCategories = null)
        {
            _pager = pager;
            _includes = includes?.ToList() ?? new List<Includes>();
            _ids = ids?.ToList() ?? new List<string>();
            _types = types?.ToList() ?? new List<CatalogType>();
            _statuses = statuses?.ToList() ?? new List<Status>();
            _taxCategories = taxCategories?.ToList() ?? new List<TaxCategory>();

            ValidateIncludes(_includes);
            ValidateIds(_ids);
            ValidateTypes(_types);
            ValidateStatuses(_statuses);
            ValidateTaxCategories(_taxCategories);
        }

        private void ValidateIncludes(List<Includes> includes)
        {
            if (includes.Any(include => include == null))
            {
                throw new ArgumentException("includes cannot contain null values", nameof(includes));
            }
        }

        private void ValidateIds(List<string> ids)
        {
            if (ids.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException("ids cannot contain null or empty values", nameof(ids));
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

        private void ValidateTaxCategories(List<TaxCategory> taxCategories)
        {
            if (taxCategories.Any(category => category == null))
            {
                throw new ArgumentException("taxCategories cannot contain null values", nameof(taxCategories));
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

            if (_statuses.Any())
            {
                parameters["status"] = string.Join(",", _statuses.Select(x => x.ToString().ToLower()));
            }

            if (_taxCategories.Any())
            {
                parameters["tax_category"] = string.Join(",", _taxCategories.Select(x => x.ToString().ToLower()));
            }

            return parameters;
        }
    }
}