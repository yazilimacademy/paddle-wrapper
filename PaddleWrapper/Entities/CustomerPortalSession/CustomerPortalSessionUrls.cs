using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.CustomerPortalSession
{
    public class CustomerPortalSessionUrls
    {
        [JsonPropertyName("general")]
        public CustomerPortalSessionGeneralUrl General { get; }

        [JsonPropertyName("subscriptions")]
        public IReadOnlyList<CustomerPortalSessionSubscriptionUrl> Subscriptions { get; }

        private CustomerPortalSessionUrls(
            CustomerPortalSessionGeneralUrl general,
            IReadOnlyList<CustomerPortalSessionSubscriptionUrl> subscriptions)
        {
            General = general;
            Subscriptions = subscriptions;
        }

        public static CustomerPortalSessionUrls From(Dictionary<string, object> data)
        {
            CustomerPortalSessionGeneralUrl general = CustomerPortalSessionGeneralUrl.From((Dictionary<string, object>)data["general"]);
            List<CustomerPortalSession.CustomerPortalSessionSubscriptionUrl> subscriptions = new List<CustomerPortalSessionSubscriptionUrl>();

            if (data.ContainsKey("subscriptions"))
            {
                object[] subscriptionsData = (object[])data["subscriptions"];
                foreach (object item in subscriptionsData)
                {
                    subscriptions.Add(CustomerPortalSessionSubscriptionUrl.From((Dictionary<string, object>)item));
                }
            }

            return new CustomerPortalSessionUrls(general, subscriptions);
        }
    }
}