using System;
using System.Threading.Tasks;

namespace PaddleWrapper.Core.Services.Cache
{
    /// <summary>
    /// Paddle API yanıtları için cache arayüzü.
    /// </summary>
    public interface IPaddleCache
    {
        /// <summary>
        /// Cache'den veri getirir.
        /// </summary>
        /// <typeparam name="T">Cache'lenecek verinin tipi.</typeparam>
        /// <param name="key">Cache anahtarı.</param>
        /// <returns>Cache'lenmiş veri veya null.</returns>
        Task<T> GetAsync<T>(string key) where T : class;

        /// <summary>
        /// Veriyi cache'e ekler.
        /// </summary>
        /// <typeparam name="T">Cache'lenecek verinin tipi.</typeparam>
        /// <param name="key">Cache anahtarı.</param>
        /// <param name="value">Cache'lenecek veri.</param>
        /// <param name="expirationTime">Cache süresi.</param>
        Task SetAsync<T>(string key, T value, TimeSpan expirationTime) where T : class;

        /// <summary>
        /// Cache'den veriyi siler.
        /// </summary>
        /// <param name="key">Silinecek verinin cache anahtarı.</param>
        Task RemoveAsync(string key);
    }
} 