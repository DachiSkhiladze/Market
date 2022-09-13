using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using MediatR;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CartServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.CartServices
{
    public class CartItemServices : BaseService<CartItem, CartItemModel>, ICartItemServices
    {
        private readonly IProductServices productServices;
        private static object locker = new object();
        public CartItemServices(IMediator mediator, IProductServices productServices) : base(mediator)
        {
            this.productServices = productServices;
        }


        public async Task<CartItemModel> CheckIfAlreadyExists(CartItemModel model) // Checking If Product Already Exists in User's Cart
        {
            return await GetModels(o => o.UserId.Equals(model.UserId) && o.ProductId.Equals(model.ProductId)).FirstOrDefaultAsync();
        }

        public async IAsyncEnumerable<CartItemModel> GetModels(Func<CartItem, bool> predicate)
        {
            var models = base.GetModels(predicate);
            await foreach (var model in models)
            {
                var product = await productServices.GetModels(o => o.Id.Equals(model.ProductId)).FirstOrDefaultAsync();
                model.Product = product;
                yield return model;
            }
        }

        public async Task<CartItemModel> InsertAsync(CartItemModel model, int quantity) // Adding new Item in cart or increasing in quantity based on its existence
        {
            lock (locker)
            {
                var entity = CheckIfAlreadyExists(model).Result;
                if (entity == null)
                {
                    return base.InsertAsync(model).Result;
                }
                else if (quantity >= 1)
                {
                    entity.Quantity = quantity;   // Increasing Quantity If Already Exists
                    return this.UpdateAsync(entity).Result;
                }
                throw new InvalidOperationException();
            }
        }

        public async Task<double> GetPrice(Guid userId)
        {
            var cart = this.GetModels(o => o.UserId.Equals(userId));
            double price = 0;
            await foreach (var item in cart)
            {
                price += (double)(item.Quantity * item.Product.Price);
            }
            return price;
        }

        public async Task DeleteFromCart(CartItemModel model)
        {
            var entity = await CheckIfAlreadyExists(model);
            await base.DeleteAsync(entity);
        }
    }
}
