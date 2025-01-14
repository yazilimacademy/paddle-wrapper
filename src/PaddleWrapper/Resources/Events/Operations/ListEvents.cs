using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Events.Operations
{
    public class ListEvents : IHasParameters
    {
        private readonly Pager? _pager;

        public ListEvents(Pager? pager = null)
        {
            _pager = pager;
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

            return parameters;
        }
    }
}