using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queries.Declarations.Shared;
using System.Security.Claims;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IServicesFactory servicesFactory;
        private readonly IMediator mediator;
        public CartController(IServicesFactory servicesFactory, IMediator mediator)
        {
            this.servicesFactory = servicesFactory;
            this.mediator = mediator;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("AddInCart/{productId}")]
        public async Task<IActionResult> AddInCart(Guid productId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            IEnumerable<Claim> claim = identity.Claims;

            var userEmail = claim
                .Where(x => x.Type == ClaimTypes.Email)
                .FirstOrDefault()
                .Value;

            var userModel = await mediator.Send(new GetSingleQuery<User, UserModel>(o => o.Email.Equals(userEmail)));

            var cartItem = new CartItemModel() { UserId = userModel.Id, ProductId = productId, Quantity = 1 };

            var service = servicesFactory.GetService<ICartItemServices>();

            var bubu = "tests";

            await service.InsertAsync(cartItem);

            return Ok();
        }
    }
}
