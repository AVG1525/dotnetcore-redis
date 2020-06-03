namespace RedisCache.Entitie.Request
{
    public class CacheRequest
    {
        public string Key { get; private set; }
        public string Values { get; private set; }
        public double ExpirationTimeSeconds { get; private set; }
    }
}
