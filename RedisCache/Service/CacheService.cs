using RedisCache.Entitie.Request;
using RedisCache.Interface;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace RedisCache.Service
{
    public class CacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public CacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var cache = _connectionMultiplexer.GetDatabase();
            return await cache.StringGetAsync(key);
        }

        public async Task<bool> SetCacheValueAsync(CacheRequest cacheRequest)
        {
            TimeSpan timeToLife = TimeSpan.FromSeconds(cacheRequest.ExpirationTimeSeconds);
            var cache = _connectionMultiplexer.GetDatabase();

            return await cache.StringSetAsync(cacheRequest.Key, cacheRequest.Values, timeToLife);
        }
    }
}
