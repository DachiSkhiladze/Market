using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions
{
    public interface IProductPicturesServices : IBaseService<ProductPictures, ProductPicturesModel>
    {
        Task InsertAsync(IFormFileCollection Files, Guid pictureId);

        IAsyncEnumerable<string> GetPicturesByProductId(Guid productId);
    }
}
