using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.CustomerPortalSession
{
    public class CustomerPortalSessionGeneralUrl
    {
        [JsonPropertyName("overview")]
        public string Overview { get; }

        private CustomerPortalSessionGeneralUrl(string overview)
        {
            Overview = overview;
        }

        public static CustomerPortalSessionGeneralUrl From(Dictionary<string, object> data)
        {
            return new CustomerPortalSessionGeneralUrl(
                overview: (string)data["overview"]
            );
        }
    }
} 