using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Orders;
using MediatR;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.OrderServices
{
    public class OrderProductService : BaseService<OrderProduct, OrderProductModel>, IOrderProductServices
    {
        public OrderProductService(IMediator mediator) : base(mediator)
        {

        }
    }
}
