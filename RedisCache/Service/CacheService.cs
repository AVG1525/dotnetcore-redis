using Microsoft.Extensions.Caching.Distributed;
using RedisCache.Interface;
using System;

namespace RedisCache.Service
{
    public class CacheService : ICacheService
    {
        public string GetCache(IDistributedCache cache, string key)
        {
            return cache.GetString(key);
        }

        public string SetCache(IDistributedCache cache, string key, string value)
        {
            DistributedCacheEntryOptions timeToLife =
                          new DistributedCacheEntryOptions();

            return cache.SetStringAsync(
                key, 
                value,
                timeToLife.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
        }
    }
}
