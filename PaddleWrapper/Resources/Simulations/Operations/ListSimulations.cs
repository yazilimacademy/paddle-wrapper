using PaddleWrapper.Entities.Simulations;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Simulations.Operations
{
    public class ListSimulations : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly string[] _notificationSettingIds;
        private readonly string[] _ids;
        private readonly SimulationStatus[] _statuses;

        public ListSimulations(
            Pager? pager = null,
            string[]? notificationSettingIds = null,
            string[]? ids = null,
            SimulationStatus[]? statuses = null)
        {
            _pager = pager;
            _notificationSettingIds = notificationSettingIds ?? Array.Empty<string>();
            _ids = ids ?? Array.Empty<string>();
            _statuses = statuses ?? Array.Empty<SimulationStatus>();
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

            if (_notificationSettingIds.Any())
            {
                parameters["notification_setting_id"] = string.Join(",", _notificationSettingIds);
            }

            if (_ids.Any())
            {
                parameters["id"] = string.Join(",", _ids);
            }

            if (_statuses.Any())
            {
                parameters["status"] = string.Join(",", _statuses.Select(s => s.ToString().ToLower()));
            }

            return parameters;
        }
    }
}