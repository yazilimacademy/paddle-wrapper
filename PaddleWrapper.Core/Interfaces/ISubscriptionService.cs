using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Subscription;

namespace PaddleWrapper.Core.Interfaces
{
    public interface ISubscriptionService
    {
        Task<PaddleResponse<Subscription>> GetSubscriptionAsync(int subscriptionId);
        Task<PaddleResponse<Subscription[]>> ListUserSubscriptionsAsync(int userId);
        Task<PaddleResponse<Subscription>> UpdateSubscriptionAsync(int subscriptionId, Subscription subscription);
        Task<PaddleResponse<Subscription>> CancelSubscriptionAsync(int subscriptionId);
        Task<PaddleResponse<Subscription>> PauseSubscriptionAsync(int subscriptionId);
        Task<PaddleResponse<Subscription>> ResumeSubscriptionAsync(int subscriptionId);
    }
}