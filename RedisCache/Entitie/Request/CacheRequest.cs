namespace RedisCache.Entitie.Request
{
    public class CacheRequest
    {
        public string Key { get; set; }
        public string Values { get; set; }
        public double ExpirationTimeSeconds { get; set; }
    }
}
