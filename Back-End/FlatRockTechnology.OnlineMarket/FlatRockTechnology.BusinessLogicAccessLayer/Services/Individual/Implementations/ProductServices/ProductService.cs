﻿using Commands.Declarations.Individual.Products;
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
                model.Pictures = new List<string>() { (await productPicturesService.GetPicturesByProductId(model.Id)).Count().ToString()};
                yield return model;
            }
        }


        public async Task<ProductModel> InsertAsync(ProductModel model)
        {
            var product = await mediator.Send(new CreateProductCommand(model));
            await productPicturesService.InsertAsync(model.Pictures, product.Id); // Inserting Pictures
            return product;// Inserting New Data
        }

    }
}
