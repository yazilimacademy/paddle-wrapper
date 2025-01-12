using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Resources.Adjustments.Operations
{
    public class GetAdjustmentCreditNote : IHasParameters
    {
        private readonly Disposition? _disposition;

        public GetAdjustmentCreditNote(Disposition? disposition = null)
        {
            _disposition = disposition;
        }

        public IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (_disposition.HasValue)
            {
                parameters["disposition"] = _disposition.Value;
            }

            return parameters;
        }
    }
}