using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisCache.Interface;

namespace RedisCache.Controllers
{
    [Route("api/[controller]")]
    public class CacheController : BaseController
    {
        private readonly ICacheService _cacheService;

        [HttpGet("{key}")]
        public IActionResult Get([FromServices]IDistributedCache cache, string key)
        {
            return Ok(_cacheService.GetCache(cache, key));
        }

        [HttpPost]
        public IActionResult Post([FromServices]IDistributedCache cache, string key, object value)
        {
            return Ok(_cacheService.SetCache(cache, key, value));
        }
    }
}
