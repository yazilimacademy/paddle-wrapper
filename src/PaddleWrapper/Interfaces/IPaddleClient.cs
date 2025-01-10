using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for the Paddle API client
    /// </summary>
    public interface IPaddleClient
    {
        /// <summary>
        /// Sends a GET request to the specified endpoint
        /// </summary>
        /// <typeparam name="TResponse">The type of the response</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<TResponse> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a POST request to the specified endpoint
        /// </summary>
        /// <typeparam name="TRequest">The type of the request body</typeparam>
        /// <typeparam name="TResponse">The type of the response</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="request">The request body</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a PATCH request to the specified endpoint
        /// </summary>
        /// <typeparam name="TRequest">The type of the request body</typeparam>
        /// <typeparam name="TResponse">The type of the response</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="request">The request body</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<TResponse> PatchAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a DELETE request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task DeleteAsync(string endpoint, CancellationToken cancellationToken = default);
    }
}