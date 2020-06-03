using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisCache.Entitie.Request;
using RedisCache.Interface;

namespace RedisCache.Controller
{
    [Route("api/[controller]")]
    public class CacheController : BaseController
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("{key}")]
        public IActionResult Get([FromServices]IDistributedCache cache, string key)
        {
            return Ok(_cacheService.GetCache(cache, key));
        }

        [HttpPost]
        public IActionResult Post([FromServices]IDistributedCache cache, [FromBody]CacheRequest cacheRequest)
        {
            return Ok(_cacheService.SetCache(cache, cacheRequest));
        }
    }
}
