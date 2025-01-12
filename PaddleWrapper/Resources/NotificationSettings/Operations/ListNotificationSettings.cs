using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.NotificationSettings.Operations
{
    public class ListNotificationSettings : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly bool? _active;
        private readonly NotificationSettingTrafficSource? _trafficSource;

        public ListNotificationSettings(
            Pager? pager = null,
            bool? active = null,
            NotificationSettingTrafficSource? trafficSource = null)
        {
            _pager = pager;
            _active = active;
            _trafficSource = trafficSource;
        }

        public Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = _pager?.GetParameters() ?? new Dictionary<string, object>();

            if (_active.HasValue)
            {
                parameters["active"] = _active.Value.ToString().ToLowerInvariant();
            }

            if (_trafficSource.HasValue)
            {
                parameters["traffic_source"] = _trafficSource.Value.ToString();
            }

            return parameters;
        }
    }
}