using PaddleWrapper.Api;

namespace PaddleWrapper
{
    public class PaddleClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public PaddleClient(string apiKey, string baseUrl = "https://api.paddle.com/")
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "PaddleWrapper-DotNet/1.0");
        }

        // Prices API
        public PricesApi Prices => new(_httpClient);

        // Products API
        public ApiResponse Products => new(_httpClient);

        // Webhooks API
        public WebhooksApi Webhooks => new(_httpClient);

        // Addresses API
        public AddressesApi Addresses => new(_httpClient);

        // Customers API
        public CustomersApi Customers => new(_httpClient);

        // Discounts API
        public DiscountsApi Discounts => new(_httpClient);

        // Businesses API
        public BusinessesApi Businesses => new(_httpClient);

        // Transactions API
        public TransactionsApi Transactions => new(_httpClient);

        // Notifications API
        public NotificationsApi Notifications => new(_httpClient);

        // Subscriptions API
        public SubscriptionsApi Subscriptions => new(_httpClient);
    }
}