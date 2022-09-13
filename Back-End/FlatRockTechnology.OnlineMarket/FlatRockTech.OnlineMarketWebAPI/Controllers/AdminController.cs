using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("IsAdmin")]
        public IActionResult IsAdmin()
        {
            return Ok();
        }
    }
}
