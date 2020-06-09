using Microsoft.AspNetCore.Mvc;
using RedisCache.Entitie.Request;
using RedisCache.Interface;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get(string key)
        {
            var value = await _cacheService.GetCacheValueAsync(key);
            return !string.IsNullOrWhiteSpace(value) ? (IActionResult) Ok(value) : NotFound(value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CacheRequest cacheRequest)
        {
            bool ret = await _cacheService.SetCacheValueAsync(cacheRequest);
            return ret ? (IActionResult) Ok(ret) : BadRequest(ret);
        }
    }
}
