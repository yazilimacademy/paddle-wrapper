using System.Threading.Tasks;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Event;

namespace PaddleWrapper.Core.Interfaces
{
    /// <summary>
    /// Olay işlemleri için servis arayüzü.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Olay detaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Event>> GetEventAsync(string eventId);

        /// <summary>
        /// Olay listesini getirir.
        /// </summary>
        Task<PaddleResponse<Event[]>> ListEventsAsync();

        /// <summary>
        /// Müşterinin olaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Event[]>> GetCustomerEventsAsync(string customerId);

        /// <summary>
        /// Aboneliğin olaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Event[]>> GetSubscriptionEventsAsync(string subscriptionId);

        /// <summary>
        /// İşlemin olaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Event[]>> GetTransactionEventsAsync(string transactionId);

        /// <summary>
        /// Olayı yeniden işler.
        /// </summary>
        Task<PaddleResponse<bool>> RetryEventAsync(string eventId);

        /// <summary>
        /// Olayı işaretler.
        /// </summary>
        Task<PaddleResponse<bool>> MarkEventAsync(string eventId, string status);

        /// <summary>
        /// Olay türlerini getirir.
        /// </summary>
        Task<PaddleResponse<EventType[]>> GetEventTypesAsync();
    }
} 