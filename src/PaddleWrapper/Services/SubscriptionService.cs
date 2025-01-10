using Microsoft.Extensions.Logging;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Subscriptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Services
{
    /// <summary>
    /// Service for managing subscriptions in the Paddle system
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IPaddleClient _client;
        private readonly ILogger<SubscriptionService> _logger;
        private const string BasePath = "/subscriptions";

        /// <summary>
        /// Creates a new instance of SubscriptionService
        /// </summary>
        public SubscriptionService(IPaddleClient client, ILogger<SubscriptionService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Subscription>>> ListSubscriptionsAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving list of subscriptions");
            return await _client.GetAsync<PaddleResponse<List<Subscription>>>(BasePath, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Subscription>> GetSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(subscriptionId))
            {
                throw new ArgumentException("Subscription ID must be provided", nameof(subscriptionId));
            }

            _logger.LogInformation("Retrieving subscription with ID: {SubscriptionId}", subscriptionId);
            return await _client.GetAsync<PaddleResponse<Subscription>>($"{BasePath}/{subscriptionId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Subscription>> CreateSubscriptionAsync(Subscription subscription, CancellationToken cancellationToken = default)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }

            _logger.LogInformation("Creating new subscription for customer: {CustomerId}", subscription.CustomerId);
            return await _client.PostAsync<Subscription, PaddleResponse<Subscription>>(BasePath, subscription, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Subscription>> UpdateSubscriptionAsync(string subscriptionId, Subscription subscription, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(subscriptionId))
            {
                throw new ArgumentException("Subscription ID must be provided", nameof(subscriptionId));
            }

            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }

            _logger.LogInformation("Updating subscription with ID: {SubscriptionId}", subscriptionId);
            return await _client.PatchAsync<Subscription, PaddleResponse<Subscription>>($"{BasePath}/{subscriptionId}", subscription, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Subscription>> PauseSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(subscriptionId))
            {
                throw new ArgumentException("Subscription ID must be provided", nameof(subscriptionId));
            }

            _logger.LogInformation("Pausing subscription with ID: {SubscriptionId}", subscriptionId);
            return await _client.PostAsync<object, PaddleResponse<Subscription>>($"{BasePath}/{subscriptionId}/pause", null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Subscription>> ResumeSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(subscriptionId))
            {
                throw new ArgumentException("Subscription ID must be provided", nameof(subscriptionId));
            }

            _logger.LogInformation("Resuming subscription with ID: {SubscriptionId}", subscriptionId);
            return await _client.PostAsync<object, PaddleResponse<Subscription>>($"{BasePath}/{subscriptionId}/resume", null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Subscription>> CancelSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(subscriptionId))
            {
                throw new ArgumentException("Subscription ID must be provided", nameof(subscriptionId));
            }

            _logger.LogInformation("Canceling subscription with ID: {SubscriptionId}", subscriptionId);
            return await _client.PostAsync<object, PaddleResponse<Subscription>>($"{BasePath}/{subscriptionId}/cancel", null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Subscription>>> ListCustomerSubscriptionsAsync(string customerId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("Customer ID must be provided", nameof(customerId));
            }

            _logger.LogInformation("Retrieving subscriptions for customer with ID: {CustomerId}", customerId);
            return await _client.GetAsync<PaddleResponse<List<Subscription>>>($"{BasePath}?customer_id={customerId}", cancellationToken);
        }
    }
}