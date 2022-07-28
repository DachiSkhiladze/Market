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

        [Authorize(Roles ="Administrator")]
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
        public async Task<UserModel> RegisterUser([FromBody] UserRegisterModel model)
        {
            return await userServiceProxy.Register(model);
        }

        [HttpPost]
        [Route("LogInUser")]
        public async Task<string> LogInUser([FromBody] UserLoginModel model)
        {
            return await userServiceProxy.LogIn(model);
        }

        [HttpGet]
        [Route("SendEmail")]
        public string Send()
        {
            EmailSender emailSender = new EmailSender();
            return emailSender.Send("dachiskhiladze@bubu.com", "Dachi", "Skhiladze");
        }

        [HttpGet]
        [Route("ConfirmEmail/{code}")]
        public async Task<bool> ConfirmEmail(string code)
        {
            return await servicesFactory.GetService<IUserServices>().ConfirmEmail(code);
        }
    }
}