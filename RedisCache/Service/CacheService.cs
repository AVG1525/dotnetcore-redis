using Microsoft.Extensions.Caching.Distributed;
using RedisCache.Entitie.Request;
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

        public bool SetCache(IDistributedCache cache, CacheRequest cacheRequest)
        {
            try { 
                DistributedCacheEntryOptions timeToLife =
                              new DistributedCacheEntryOptions();

                timeToLife.SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheRequest.ExpirationTimeSeconds));

                cache.SetString(cacheRequest.Key, cacheRequest.Values, timeToLife);
                
                return true;
            } catch (Exception)
            {
                return false;
            }

        }
    }
}
