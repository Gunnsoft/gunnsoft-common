using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Gunnsoft.Common.Caching.Memory
{
    public class MemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCache
        (
            IMemoryCache memoryCache
        )
        {
            _memoryCache = memoryCache;
        }

        public TValue GetOrSet<TValue>
        (
            object k,
            Func<TValue> factory,
            CacheSettings cacheOptions = null
        )
        {
            return _memoryCache.GetOrCreate(k, f =>
            {
                cacheOptions = cacheOptions ?? CacheSettings.Default;

                if (cacheOptions == null)
                {
                    return factory();
                }

                f.AbsoluteExpirationRelativeToNow = cacheOptions.AbsoluteExpirationRelativeToNow;
                f.SlidingExpiration = cacheOptions.SlidingExpiration;

                return factory();
            });
        }

        public async Task<TValue> GetOrSetAsync<TValue>
        (
            object k,
            Func<Task<TValue>> factory,
            CacheSettings cacheOptions = null
        )
        {
            return await _memoryCache.GetOrCreateAsync(k, f =>
            {
                cacheOptions = cacheOptions ?? CacheSettings.Default;

                if (cacheOptions == null)
                {
                    return factory();
                }

                f.AbsoluteExpirationRelativeToNow = cacheOptions.AbsoluteExpirationRelativeToNow;
                f.SlidingExpiration = cacheOptions.SlidingExpiration;

                return factory();
            });
        }

        public void Remove
        (
            object key
        )
        {
            _memoryCache.Remove(key);
        }
    }
}