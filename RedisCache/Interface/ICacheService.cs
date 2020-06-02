using Microsoft.Extensions.Caching.Distributed;

namespace RedisCache.Interface
{
    public interface ICacheService
    {
        string GetCache(IDistributedCache cache, string key);
        string SetCache(IDistributedCache cache, string key, string value);
    }
}
