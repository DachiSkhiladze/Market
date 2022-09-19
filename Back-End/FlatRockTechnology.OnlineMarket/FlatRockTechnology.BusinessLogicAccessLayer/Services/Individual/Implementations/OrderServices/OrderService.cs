using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Orders;
using MediatR;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.AddressServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.OrderServices
{
    public class OrderService : BaseService<Order, OrderModel>, IOrderServices
    {
        private readonly IOrderProductServices orderProductServices;
        private readonly IAddressServices addressServices;
        public OrderService(IMediator mediator, IOrderProductServices orderProductServices, IAddressServices addressServices) : base(mediator)
        {
            this.orderProductServices = orderProductServices;
            this.addressServices = addressServices;
        }

        public async Task<OrderModel> SetOrderDone(Guid orderId)
        {
            var model = await this.GetSingleModel(o => o.Id.Equals(orderId));
            model.Status = "Done";
            return await this.UpdateAsync(model);
        }

        public new async IAsyncEnumerable<OrderModel> GetModels()
        {
            var orders = await base.GetModels();
            foreach (var order in orders)
            {
                order.orders = await orderProductServices.GetModelsByOrderId(order.Id).ToListAsync();
                var addressModel = await addressServices.GetSingleModel(o => o.Id.Equals(order.AddressId));
                order.Address = addressModel.Name;
                yield return order;
            }
        }
    }
}
