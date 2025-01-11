using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionManagementUrls
    {
        [JsonPropertyName("update_payment_method")]
        public string? UpdatePaymentMethod { get; }

        [JsonPropertyName("cancel")]
        public string Cancel { get; }

        private SubscriptionManagementUrls(
            string? updatePaymentMethod,
            string cancel)
        {
            UpdatePaymentMethod = updatePaymentMethod;
            Cancel = cancel;
        }

        public static SubscriptionManagementUrls From(Dictionary<string, object> data)
        {
            return new SubscriptionManagementUrls(
                updatePaymentMethod: data.ContainsKey("update_payment_method") ? (string?)data["update_payment_method"] : null,
                cancel: (string)data["cancel"]
            );
        }
    }
}