using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FlatRockTechnology.OnlineMarket.Models.Users;
using FlatRockTechnology.OnlineMarket.Models.Products;
using Commands.Declarations.Individual.Products;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory;
using AuthenticationLayer.Proxy;
using FlatRockTechnology.OnlineMarket.Models.Mapper;
using AutoMapper;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices;
using AuthenticationLayer.Proxy.Abstractions;

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

        public UserController(IMediator mediator, IServiceProvider service, IUserServiceProxy userServiceProxy)
        {
            _mediator = mediator;
            _serviceProvider = service;
            this.userServiceProxy = userServiceProxy;
        }

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
        public async Task<bool> LogInUser([FromBody] UserLoginModel model)
        {
            return await userServiceProxy.LogIn(model);
        }
    }
}