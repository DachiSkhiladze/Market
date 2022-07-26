using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.Models.Users;
using FlatRockTechnology.OnlineMarket.Models.Products;
using Queries.Declarations.Shared;
using Commands.Declarations.Individual.Products;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public UserController( IUserServices userServices, IMediator mediator, IServiceProvider service)
        {
            _userServices = userServices;
            _mediator = mediator;
            _serviceProvider = service;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async IAsyncEnumerable<UserModel> GetAll()
        {
            ServicesFlyWeight servicesFlyWeight = new ServicesFlyWeight(_serviceProvider);
            var bubu = servicesFlyWeight.GetService<IUserServices>();
            await foreach (var user in bubu.GetModels(o => o.Id != ""))
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
    }
}