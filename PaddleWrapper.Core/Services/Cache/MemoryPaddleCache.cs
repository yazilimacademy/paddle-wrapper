using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PaddleWrapper.Core.Interfaces;

namespace PaddleWrapper.Core.Services.Cache
{
    /// <summary>
    /// In-memory cache implementasyonu.
    /// </summary>
    public class MemoryPaddleCache : IPaddleCache
    {
        private readonly IMemoryCache _cache;
        private readonly IPaddleLogger _logger;

        public MemoryPaddleCache(IMemoryCache cache, IPaddleLogger logger)
        {
            _cache = cache;
            _logger = logger;
        }

        /// <inheritdoc/>
        public Task<T> GetAsync<T>(string key) where T : class
        {
            try
            {
                var value = _cache.Get<T>(key);
                if (value != null)
                {
                    _logger.LogDebug($"Cache hit for key: {key}");
                }
                else
                {
                    _logger.LogDebug($"Cache miss for key: {key}");
                }
                return Task.FromResult(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting value from cache for key: {key}", ex);
                return Task.FromResult<T>(null);
            }
        }

        /// <inheritdoc/>
        public Task SetAsync<T>(string key, T value, TimeSpan expirationTime) where T : class
        {
            try
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(expirationTime)
                    .SetAbsoluteExpiration(DateTimeOffset.Now.Add(expirationTime.Add(TimeSpan.FromMinutes(5))))
                    .SetSize(1); // Her cache girişi 1 birim olarak sayılır

                _cache.Set(key, value, cacheEntryOptions);
                _logger.LogDebug($"Value cached for key: {key}, expiration: {expirationTime.TotalMinutes} minutes");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error setting value in cache for key: {key}", ex);
                return Task.CompletedTask;
            }
        }

        /// <inheritdoc/>
        public Task RemoveAsync(string key)
        {
            try
            {
                _cache.Remove(key);
                _logger.LogDebug($"Cache entry removed for key: {key}");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing value from cache for key: {key}", ex);
                return Task.CompletedTask;
            }
        }
    }
} 