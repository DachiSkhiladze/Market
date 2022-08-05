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

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserServiceProxy userServiceProxy;
        private readonly IServicesFactory servicesFactory;

        public UserController(IServicesFactory servicesFactory, IMediator mediator, IServiceProvider service, IUserServiceProxy userServiceProxy)
        {
            _mediator = mediator;
            _serviceProvider = service;
            this.userServiceProxy = userServiceProxy;
            this.servicesFactory = servicesFactory;
        }

        [HttpPost]
        [Route("Pay")]
        public async Task<dynamic> Pay(PaymentModel model)
        {
            return await MakePayment.PayAsync(model.CardNumber, model.Month, model.Year, model.CVC, model.Value);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("GetAllUsers")]
        public async IAsyncEnumerable<ProductModel> GetAll()
        {
            ServicesFlyWeight servicesFlyWeight = new ServicesFlyWeight(_serviceProvider);
            var bubu = servicesFlyWeight.GetService<IProductServices>();
            await foreach (var user in bubu.GetModels())
            {
                yield return user;
            }
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<ProductModel> CreateProduct([FromBody] ProductModel model)
        {
            return await _mediator.Send(new CreateProductCommand(model));
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
                var RefreshToken = Guid.NewGuid().ToString();
                Response.Cookies.Append("X-Access-Token", token.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                Response.Cookies.Append("X-Refresh-Token", token.RefreshToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });

                return Ok(token);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(string tokenModel)
        {
            var model = await userServiceProxy.Refresh(tokenModel);
            if(model.RefreshToken == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("SendEmail")]
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
    }
}