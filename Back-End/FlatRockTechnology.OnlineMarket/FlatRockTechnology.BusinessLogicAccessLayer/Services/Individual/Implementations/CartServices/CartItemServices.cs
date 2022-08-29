using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using MediatR;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.CartServices
{
    public class CartItemServices : BaseService<CartItem, CartItemModel>, ICartItemServices
    {
        public CartItemServices(IMediator mediator) : base(mediator)
        {

        }

        public async Task<CartItemModel> InsertAsync(CartItemModel model) // Adding new Item in cart or increasing in quantity based on its existence
        {
            var entity = CheckIfAlreadyExists(model).Result;
            if (entity != null)
            {
                entity.Quantity += 1;   // Increasing Quantity If Already Exists
                return await this.UpdateAsync(entity);
            }
            return await base.InsertAsync(model);   // Otherwise Returning Newly Created Record
        }

        public async Task<CartItemModel> CheckIfAlreadyExists(CartItemModel model) // Checking If Product Already Exists in User's Cart
        {
            return await GetModels(o => o.UserId.Equals(model.UserId) && o.ProductId.Equals(model.ProductId)).FirstOrDefaultAsync();
        }
    }
}
