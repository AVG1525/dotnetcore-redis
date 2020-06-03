using Microsoft.Extensions.Caching.Distributed;
using RedisCache.Entitie.Request;

namespace RedisCache.Interface
{
    public interface ICacheService
    {
        string GetCache(IDistributedCache cache, string key);
        bool SetCache(IDistributedCache cache, CacheRequest cacheRequest);
    }
}
