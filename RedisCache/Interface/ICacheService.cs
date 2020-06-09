using RedisCache.Entitie.Request;
using System.Threading.Tasks;

namespace RedisCache.Interface
{
    public interface ICacheService
    {
        Task<string> GetCacheValueAsync(string key);
        Task<bool> SetCacheValueAsync(CacheRequest cacheRequest);
    }
}
