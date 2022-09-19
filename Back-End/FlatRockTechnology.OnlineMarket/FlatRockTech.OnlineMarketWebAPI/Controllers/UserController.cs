using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FlatRockTechnology.OnlineMarket.Models.Users;
using FlatRockTechnology.OnlineMarket.Models.Products;
using Commands.Declarations.Individual.Products;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory;
using AuthenticationLayer.Proxy.Abstractions;
using Microsoft.AspNetCore.Authorization;
using EmailLayer;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using Payment.Models;
using Payment.Processing.Implementations;
using System.Linq;
using FlatRockTechnology.OnlineMarket.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IUserServiceProxy userServiceProxy;
        private readonly IServicesFlyweight servicesFactory;

        public UserController(IServicesFlyweight servicesFactory, IUserServiceProxy userServiceProxy)
        {
            this.userServiceProxy = userServiceProxy;
            this.servicesFactory = servicesFactory;
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IEnumerable<RoleModel>> GetRoles()
        {
            var roles = (await this.servicesFactory.GetService<IRoleServices>().GetModels());
            return roles;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("IsLogged")]
        public async Task<IActionResult> IsLogged()
        {
            return Ok();
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterModel model)
        {
            if (Request.Headers.Keys.Contains("Origin"))
            {
                var origin = Request.Headers["Origin"];
                return await userServiceProxy.Register(model, origin) == null ? BadRequest() : Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("LogInUser")]
        public async Task<IActionResult> LogInUser([FromBody] UserLoginModel model)
        {
            var token = await userServiceProxy.LogIn(model);
            if (!token.Equals(""))
            {
                Response.Cookies.Append("X-Access-Token", token.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                Response.Cookies.Append("X-Refresh-Token", token.RefreshToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });

                return Ok(token);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody]string tokenModel)
        {
            var model = await userServiceProxy.Refresh(tokenModel);
            if(model.RefreshToken == null)
            {
                return BadRequest();
            }
             return Ok(model);
        }

        [HttpGet("SendEmail")]
        public string Send()
        {
            EmailSender emailSender = new EmailSender();
            return emailSender.Send("dachiskhiladze@bubu.com", "Dachi", "Skhiladze", ""); // Origin missing exception thrown
        }

        [HttpGet]
        [Route("ConfirmEmail/{code}")]
        public async Task<IActionResult> ConfirmEmail(string code)
        {
            return await servicesFactory.GetService<IUserServices>().ConfirmEmail(code) ? Ok() : BadRequest();
        }

        [HttpPost]
        [Route("SendRecoveryMail")]
        public async Task<IActionResult> SendRecoveryMail([FromBody] SendForgotPasswordModel model)
        {
            if (Request.Headers.Keys.Contains("Origin"))
            {
                var origin = Request.Headers["Origin"];
                return await servicesFactory.GetService<IUserServices>().RecoverPassword(model.Email, origin) ? Ok() : BadRequest();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("RecoverPassword")]
        public async Task<IActionResult> RecoverPassword([FromBody] ForgotPasswordModel model)
        {
            return await servicesFactory.GetService<IUserServices>().RecoverPassword(model) ? Ok() : NotFound();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await servicesFactory.GetService<IUserServices>().GetUsersWithRoles().ToListAsync());
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("UpdateRole/{userId}/{roleId}")]
        public async Task<IActionResult> UpdateRole(Guid userId, Guid roleId)
        {
            return Ok(await servicesFactory.GetService<IUserServices>().UpdateRoleAsync(userId, roleId));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var cat = await servicesFactory.GetService<IUserServices>().GetModels(o => o.Id.Equals(id)).FirstOrDefaultAsync();
            if (cat == null)
            {
                return BadRequest();
            }
            await servicesFactory.GetService<IUserServices>().DeleteAsync(cat);
            return Ok();
        }
    }
}