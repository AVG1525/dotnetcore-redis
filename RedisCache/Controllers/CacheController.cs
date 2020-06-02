using Microsoft.AspNetCore.Mvc;

namespace RedisCache.Controllers
{
    [Route("api/[controller]")]
    public class CacheController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Okay");
        }
    }
}
