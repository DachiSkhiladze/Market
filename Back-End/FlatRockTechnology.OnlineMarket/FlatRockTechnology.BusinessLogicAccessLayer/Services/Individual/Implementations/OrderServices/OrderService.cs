using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Orders;
using MediatR;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.OrderServices
{
    public class OrderService : BaseService<Order, OrderModel>, IOrderServices
    {
        public OrderService(IMediator mediator) : base(mediator)
        {

        }
    }
}
