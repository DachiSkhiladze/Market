using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult getTest()
        {
            return Ok();
        }
    }
}
