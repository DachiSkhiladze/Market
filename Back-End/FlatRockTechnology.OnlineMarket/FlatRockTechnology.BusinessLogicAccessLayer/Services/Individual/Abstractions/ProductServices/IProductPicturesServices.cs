using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices
{
    public interface IProductPicturesServices : IBaseService<ProductPictures, ProductPicturesModel>
    {
        Task InsertAsync(IEnumerable<string> Files, Guid pictureId);

        Task<IEnumerable<ProductPicturesModel>> GetPicturesByProductId(Guid productId);
    }
}
