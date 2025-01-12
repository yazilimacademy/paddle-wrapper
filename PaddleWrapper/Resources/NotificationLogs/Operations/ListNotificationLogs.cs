using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.NotificationLogs.Operations
{
    public class ListNotificationLogs : IHasParameters
    {
        private readonly Pager? _pager;

        public ListNotificationLogs(Pager? pager = null)
        {
            _pager = pager;
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

            return parameters;
        }
    }
}