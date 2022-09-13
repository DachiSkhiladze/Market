using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices
{
    public interface IProductServices : IBaseService<Product, ProductModel>
    {
        IAsyncEnumerable<ProductModel> GetProductsWithPictures();
        Task<ProductModel> GetProductWithPictures(Func<Product, bool> predicate);
        Task<ProductModel> InsertAsync(ProductModel model);
        Task<ProductModel> UpdateAsync(ProductModel model);
    }
}
