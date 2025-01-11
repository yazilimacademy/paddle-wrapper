using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

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
            var general = CustomerPortalSessionGeneralUrl.From((Dictionary<string, object>)data["general"]);
            var subscriptions = new List<CustomerPortalSessionSubscriptionUrl>();

            if (data.ContainsKey("subscriptions"))
            {
                var subscriptionsData = (object[])data["subscriptions"];
                foreach (var item in subscriptionsData)
                {
                    subscriptions.Add(CustomerPortalSessionSubscriptionUrl.From((Dictionary<string, object>)item));
                }
            }

            return new CustomerPortalSessionUrls(general, subscriptions);
        }
    }
} 