using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServicesFlyweight services;
        public EmployeeController(IServicesFlyweight services)
        {
            this.services = services;
        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        [Route("IsEmployee")]
        public IActionResult IsEmployee()
        {
            return Ok();
        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(services.GetService<IOrderServices>().GetModels());
        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        [Route("SetProductDone/{orderId}")]
        public async Task<IActionResult> SetProductDone(Guid orderId)
        {
            await services.GetService<IOrderServices>().SetOrderDone(orderId);
            return Ok();
        }
    }
}
