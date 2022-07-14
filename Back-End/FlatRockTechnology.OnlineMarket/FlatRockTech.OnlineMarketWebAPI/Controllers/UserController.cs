using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.User;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController( IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            
            model.IsDisabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _userServices.Register(model);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
            return Ok();
        }
    }
}