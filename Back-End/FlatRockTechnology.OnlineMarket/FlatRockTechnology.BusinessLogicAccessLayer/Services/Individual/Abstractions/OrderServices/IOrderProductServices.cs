using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Orders;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices
{
    public interface IOrderProductServices : IBaseService<OrderProduct, OrderProductModel>
    {
        IAsyncEnumerable<OrderProductModel> GetModelsByOrderId(Guid orderId);
    }
}
