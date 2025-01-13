using PaddleWrapper.Resources.Addresses;
using PaddleWrapper.Resources.Adjustments;
using PaddleWrapper.Resources.Businesses;
using PaddleWrapper.Resources.CustomerPortalSessions;
using PaddleWrapper.Resources.Customers;
using PaddleWrapper.Resources.Discounts;
using PaddleWrapper.Resources.Events;
using PaddleWrapper.Resources.EventTypes;
using PaddleWrapper.Resources.NotificationLogs;
using PaddleWrapper.Resources.Notifications;
using PaddleWrapper.Resources.NotificationSettings;
using PaddleWrapper.Resources.PaymentMethods;
using PaddleWrapper.Resources.Prices;
using PaddleWrapper.Resources.PricingPreviews;
using PaddleWrapper.Resources.Products;
using PaddleWrapper.Resources.Reports;
using PaddleWrapper.Resources.SimulationRunEvents;
using PaddleWrapper.Resources.SimulationRuns;
using PaddleWrapper.Resources.Simulations;
using PaddleWrapper.Resources.SimulationTypes;
using PaddleWrapper.Resources.Subscriptions;
using PaddleWrapper.Resources.Transactions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper;

public class Client : IDisposable
{
    private const string SDK_VERSION = "1.0.0";
    private readonly Options _options;
    private string? _transactionId;

    public ProductsClient Products { get; }
    public PricesClient Prices { get; }
    public TransactionsClient Transactions { get; }
    public AdjustmentsClient Adjustments { get; }
    public CustomersClient Customers { get; }
    public CustomerPortalSessionsClient CustomerPortalSessions { get; }
    public AddressesClient Addresses { get; }
    public BusinessesClient Businesses { get; }
    public DiscountsClient Discounts { get; }
    public SubscriptionsClient Subscriptions { get; }
    public EventTypesClient EventTypes { get; }
    public EventsClient Events { get; }
    public PricingPreviewsClient PricingPreviews { get; }
    public PaymentMethodsClient PaymentMethods { get; }
    public NotificationSettingsClient NotificationSettings { get; }
    public NotificationsClient Notifications { get; }
    public NotificationLogsClient NotificationLogs { get; }
    public ReportsClient Reports { get; }
    public SimulationsClient Simulations { get; }
    public SimulationRunsClient SimulationRuns { get; }
    public SimulationRunEventsClient SimulationRunEvents { get; }
    public SimulationTypesClient SimulationTypes { get; }

    public HttpClient HttpClient { get; }

    public Client(string apiKey, Options? options = null)
    {
        _options = options ?? new Options();

        if (string.IsNullOrWhiteSpace(_options.ApiKey))
        {
            throw new ArgumentException("ApiKey is required");
        }

        HttpClient = new HttpClient
        {
            BaseAddress = new Uri(_options.Environment.GetBaseUrl())
        };

        HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        HttpClient.DefaultRequestHeaders.Add("User-Agent", $"PaddleWrapper/.NET {SDK_VERSION}");

        Products = new ProductsClient(this);
        Prices = new PricesClient(this);
        Transactions = new TransactionsClient(this);
        Adjustments = new AdjustmentsClient(this);
        Customers = new CustomersClient(this);
        CustomerPortalSessions = new CustomerPortalSessionsClient(this);
        Addresses = new AddressesClient(this);
        Businesses = new BusinessesClient(this);
        Discounts = new DiscountsClient(this);
        Subscriptions = new SubscriptionsClient(this);
        EventTypes = new EventTypesClient(this);
        Events = new EventsClient(this);
        PricingPreviews = new PricingPreviewsClient(this);
        PaymentMethods = new PaymentMethodsClient(this);
        NotificationSettings = new NotificationSettingsClient(this);
        Notifications = new NotificationsClient(this);
        NotificationLogs = new NotificationLogsClient(this);
        Reports = new ReportsClient(this);
        Simulations = new SimulationsClient(this);
        SimulationRuns = new SimulationRunsClient(this);
        SimulationRunEvents = new SimulationRunEventsClient(this);
        SimulationTypes = new SimulationTypesClient(this);
    }

    public async Task<HttpResponseMessage> GetRawAsync(string uri, IHasParameters? parameters = null)
    {
        string requestUri = uri;
        if (parameters != null)
        {
            string query = BuildQueryString(parameters.GetParameters());
            requestUri = $"{uri}?{query}";
        }

        return await RequestRawAsync(HttpMethod.Get, requestUri);
    }

    public async Task<HttpResponseMessage> PatchRawAsync(string uri, object payload)
    {
        return await RequestRawAsync(HttpMethod.Patch, uri, payload);
    }

    public async Task<HttpResponseMessage> PostRawAsync(string uri, object? payload = null, IHasParameters? parameters = null)
    {
        string requestUri = uri;
        if (parameters != null)
        {
            string query = BuildQueryString(parameters.GetParameters());
            requestUri = $"{uri}?{query}";
        }

        return await RequestRawAsync(HttpMethod.Post, requestUri, payload);
    }

    public async Task<HttpResponseMessage> DeleteRawAsync(string uri)
    {
        return await RequestRawAsync(HttpMethod.Delete, uri);
    }

    private async Task<HttpResponseMessage> RequestRawAsync(HttpMethod method, string uri, object? payload = null)
    {
        HttpRequestMessage request = new(method, uri);

        if (payload != null)
        {
            string json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
            request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        }

        _transactionId ??= Guid.NewGuid().ToString();
        request.Headers.Add("X-Transaction-ID", _transactionId);

        return await HttpClient.SendAsync(request);
    }

    private static string BuildQueryString(IDictionary<string, object> parameters)
    {
        return string.Join("&", parameters
            .Where(p => p.Value != null)
            .Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value.ToString()!)}"));
    }

    public void Dispose()
    {
        HttpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}