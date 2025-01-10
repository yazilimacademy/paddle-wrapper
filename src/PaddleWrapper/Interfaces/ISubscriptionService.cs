using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Subscriptions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for managing subscriptions in the Paddle system
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        /// Gets a list of all subscriptions
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Subscription>>> ListSubscriptionsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a subscription by its ID
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Subscription>> GetSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new subscription
        /// </summary>
        /// <param name="subscription">The subscription to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Subscription>> CreateSubscriptionAsync(Subscription subscription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing subscription
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription to update</param>
        /// <param name="subscription">The updated subscription data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Subscription>> UpdateSubscriptionAsync(string subscriptionId, Subscription subscription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Pauses a subscription
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription to pause</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Subscription>> PauseSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Resumes a paused subscription
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription to resume</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Subscription>> ResumeSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels a subscription
        /// </summary>
        /// <param name="subscriptionId">The ID of the subscription to cancel</param>
        /// <param name="effectiveFrom">When the cancellation should take effect</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Subscription>> CancelSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of subscriptions for a customer
        /// </summary>
        /// <param name="customerId">The ID of the customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Subscription>>> ListCustomerSubscriptionsAsync(string customerId, CancellationToken cancellationToken = default);
    }
}