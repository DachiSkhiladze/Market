using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Orders;
using MediatR;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.OrderServices
{
    public class OrderProductService : BaseService<OrderProduct, OrderProductModel>, IOrderProductServices
    {
        private readonly IProductServices productServices;
        public OrderProductService(IMediator mediator, IProductServices productServices) : base(mediator)
        {
            this.productServices = productServices;
        }

        public async IAsyncEnumerable<OrderProductModel> GetModelsByOrderId(Guid orderId)
        {
            var models = await base.GetModels(o => o.OrderId.Equals(orderId)).ToListAsync();
            foreach (var orderProduct in models)
            {
                var product = await productServices.GetSingleModel(o => o.Id.Equals(orderProduct.ProductId));
                orderProduct.Name = product.Name;
                yield return orderProduct;
            }
        }
    }
}
