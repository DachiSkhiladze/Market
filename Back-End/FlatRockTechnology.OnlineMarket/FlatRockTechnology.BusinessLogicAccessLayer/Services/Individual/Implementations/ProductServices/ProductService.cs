using Commands.Declarations.Individual.Products;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.ProductServices
{
    public class ProductServices : BaseService<Product, ProductModel>, IProductServices
    {
        private readonly IProductPicturesServices productPicturesService; 
        public ProductServices(IMediator mediator, IProductPicturesServices productPicturesService) : base(mediator)
        {
            this.productPicturesService = productPicturesService;
        }

        public async IAsyncEnumerable<ProductModel> GetProductsWithPictures()
        {
            var col = await base.GetModels();
            foreach (var model in col)
            {
                model.Pictures = await productPicturesService.GetPicturesByProductId(model.Id).Select(o => o.ImageURL).ToListAsync();
                yield return model;
            }
        }

        public async Task<ProductModel> GetProductWithPictures(Func<Product, bool> predicate)
        {
            var product = await base.GetSingleModel(predicate);
            product.ProductPictures = await productPicturesService.GetPicturesByProductId(product.Id).ToListAsync();
            product.Pictures = product.ProductPictures.Select(o => o.ImageURL);
            return product;
        }

        public async Task<ProductModel> InsertAsync(ProductModel model)
        {
            var product = await mediator.Send(new CreateProductCommand(model));
            await productPicturesService.InsertAsync(model.Pictures, product.Id);
            return product;
        }

        public async Task<ProductModel> UpdateAsync(ProductModel model)
        {
            var product = await mediator.Send(new UpdateProductCommand(model));
            return product;
        }
    }
}
