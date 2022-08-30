using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queries.Declarations.Shared;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{

    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        static int count = 0;
        private readonly IServicesFlyweight servicesFactory;
        private readonly IMediator mediator;
        private readonly ICartItemServices service;
        public CartController(IServicesFlyweight servicesFactory, IMediator mediator)
        {
            this.servicesFactory = servicesFactory;
            this.mediator = mediator;
            service = servicesFactory.GetService<ICartItemServices>();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("GetCartItems")]
        public async IAsyncEnumerable<CartItemModel> GetCartItems()
        {
            var userEmail = GetEmail();

            var userModel = await GetIdByEmailAsync(userEmail);

            await foreach (var item in 
                servicesFactory.GetService<ICartItemServices>().GetModels(o => o.UserId.Equals(userModel.Id)))
            {
                yield return item;
            } 
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("AddInCart/{productId}")]
        public async Task<IActionResult> AddInCart(Guid productId, int quantity)
        {
            count++;
            if(count % 10 == 0)
            {
                var test = 2342;
            }
            var userEmail = GetEmail();
    
            var userModel = await mediator.Send(new GetSingleQuery<User, UserModel>(o => o.Email.Equals(userEmail)));

            var cartItem = new CartItemModel() { UserId = userModel.Id, ProductId = productId, Quantity = 1 };

            await service.InsertAsync(cartItem, quantity);

            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("DecreaseInCart/{productId}")]
        public async Task<IActionResult> DecreaseInCart(Guid productId)
        {
            count--;
            var userEmail = GetEmail();

            var userModel = await mediator.Send(new GetSingleQuery<User, UserModel>(o => o.Email.Equals(userEmail)));

            var cartItem = new CartItemModel() { UserId = userModel.Id, ProductId = productId };
            System.Diagnostics.Debug.WriteLine("Bubu");
            service.DecreaseQuantity(cartItem).Wait();

            return Ok();
        }

        private string GetEmail()   // Returning email of user
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            IEnumerable<Claim> claim = identity.Claims;

            var userEmail = claim?
                .Where(x => x.Type == ClaimTypes.Email)?
                .FirstOrDefault()?
                .Value;
            return userEmail;
        }

        private async Task<UserModel> GetIdByEmailAsync(string email)
        {
            return await mediator.Send(new GetSingleQuery<User, UserModel>(o => o.Email.Equals(email)));
        }
    }
}
