using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Orders;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices
{
    public interface IOrderServices : IBaseService<Order, OrderModel>
    {
        new IAsyncEnumerable<OrderModel> GetModels();
        Task<OrderModel> SetOrderDone(Guid orderId);
    }
}
