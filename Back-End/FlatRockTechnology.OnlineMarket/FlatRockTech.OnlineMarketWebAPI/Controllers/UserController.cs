using FlatRockTech.OnlineMarket.BusinessLogicLayer.Handlers;
using FlatRockTech.OnlineMarket.BusinessLogicLayer;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.User;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMediator _mediator;

        public UserController( IUserServices userServices, IMediator mediator)
        {
            _userServices = userServices;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _mediator.Send(new OnlineMarket.BusinessLogicLayer.Queries.Read.GetAll<User, UserModel>());
        }
    }
}