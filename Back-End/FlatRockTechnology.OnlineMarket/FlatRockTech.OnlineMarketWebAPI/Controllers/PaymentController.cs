﻿using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Addresses;
using FlatRockTechnology.OnlineMarket.Models.Orders;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.AddressServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CartServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices;
using OnlineMarket.Models.Payment;
using Payment.Models;
using Payment.Processing.Implementations;
using Queries.Declarations.Shared;
using System.Security.Claims;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IServicesFlyweight servicesFlyweight;
        private readonly IMediator mediator;
        public PaymentController(IServicesFlyweight servicesFlyweight, IMediator mediator)
        {
            this.servicesFlyweight = servicesFlyweight;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Pay")]
        public async Task<dynamic> Pay(PaymentModel model)
        {
            return await MakePayment.PayAsync(model.CardNumber, model.Month, model.Year, model.CVC, model.Value);
        }


        [Authorize(Roles = "User, Administrator")]
        [HttpPost]
        [Route("MakeOrder")]
        public async Task<IActionResult> MakeOrder([FromBody]PaymentSubmissionModel model)
        {

            var userEmail = GetEmailFromClaims();
            var user = await GetUserByEmailAsync(userEmail);
            model.PaymentDetails.Value = (long)await servicesFlyweight.GetService<ICartItemServices>().GetPrice(user.Id);
            var cartService =  servicesFlyweight.GetService<ICartItemServices>();
            var cartItems = await cartService.GetModels(o => o.UserId.Equals(user.Id)).ToListAsync();
            var payment = model.PaymentDetails;
            model.Address.UserId = user.Id;

            var success = await MakePayment.PayAsync(payment.CardNumber, payment.Month, payment.Year, payment.CVC, payment.Value);
            if (!success)
            {
                //return BadRequest();
            }
            var addressEntity = await servicesFlyweight.GetService<IAddressServices>().InsertAsync(model.Address);
            var order = new OrderModel() { AddressId = addressEntity.Id, Status = "In Proccess", UserId = user.Id };
            var orderEntity = await servicesFlyweight.GetService<IOrderServices>().InsertAsync(order);
            var orderProductService = servicesFlyweight.GetService<IOrderProductServices>();
            foreach (var item in cartItems)
            {
                var orderProduct = new OrderProductModel() { OrderId = orderEntity.Id, ProductId = (Guid)item.ProductId, Quantity = (long)item.Quantity, PriceOfSingleProduct = (long)item.Product.Price };
                await orderProductService.InsertAsync(orderProduct);
                await cartService.DeleteAsync(item);
            }
            return Accepted();
        }

        [Authorize(Roles = "User, Administrator")]
        [HttpGet]
        [Route("GetPriceForPaying")]
        public async Task<double> GetPriceForPaying()
        {
            var userEmail = GetEmailFromClaims();
            var user = await GetUserByEmailAsync(userEmail);
            var price = await servicesFlyweight.GetService<ICartItemServices>().GetPrice(user.Id);
            return price;
        }

        private string GetEmailFromClaims()   // Returning email of user
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            IEnumerable<Claim> claim = identity.Claims;

            var userEmail = claim?
                .Where(x => x.Type == ClaimTypes.Email)?
                .FirstOrDefault()?
                .Value;
            return userEmail;
        }

        private async Task<UserModel> GetUserByEmailAsync(string email)
        {
            return await mediator.Send(new GetSingleQuery<User, UserModel>(o => o.Email.Equals(email)));
        }
    }
}
