using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Categories;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices;
using Queries.Declarations.Individual;
using Queries.Declarations.Shared;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IServicesFlyweight services;
        public ProductsController(IMediator mediator, IServicesFlyweight services)
        {
            this.mediator = mediator;
            this.services = services;
        }

        [Authorize(Roles = "Administrator")]
        [Route("InsertProduct")]
        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductModel productModel)
        {
            await services.GetService<IProductServices>().InsertAsync(productModel);

            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [Route("UpdateProduct")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel productModel)
        {
            await services.GetService<IProductServices>().UpdateAsync(productModel);

            return Ok();
        }

        [Route("GetAllProductsWithPictures")]
        [HttpGet]
        public async IAsyncEnumerable<ProductModel> GetAllProductsWithPictures()
        {
            await foreach (var item in services.GetService<IProductServices>().GetProductsWithPictures())
            {
                yield return item;
            }
        }

        [Route("GetProductWithPictures/{id}")]
        [HttpGet]
        public async Task<ProductModel> GetProductWithPictures(Guid id)
        {
            return await services.GetService<IProductServices>().GetProductWithPictures(o => o.Id.Equals(id));
        }

        [Route("GetProductWithPicturesBySubCategoryId/{orderId}")]
        [HttpGet]
        public async Task<IActionResult> GetProductWithPicturesBySubCategoryId(Guid orderId)
        {
            return Ok(services.GetService<IProductServices>().GetProductsWithPictures(orderId));
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(Guid id)
        {
            return Ok(await mediator.Send(new GetAllQuery<Product, ProductModel>()));
        }

        [Route("GetProductsBySubCategoryID/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductsBySubCategoryID(Guid id)
        {
            var response = Ok(await mediator.Send(new GetProductsBySubCategoryIDQuery(id)));
            return response;
        }

        [Route("GetCategories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var response = await mediator.Send(new GetAllQuery<Category, CategoryModel>());
            return Ok(response);
        }
        [Route("GetCategories/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCategories(Guid id)
        {
            var cat = await mediator.Send(new GetAllQuery<SubCategory, SubCategoryModel>());
            return Ok(cat.Where(o => o.CategoryId.Equals(id)));
        }
        [Authorize(Roles = "Administrator")]
        [Route("DeleteProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await services.GetService<IProductServices>().GetModels(o => o.Id.Equals(id)).FirstOrDefaultAsync();
            if(result == null)
            {
                return BadRequest();
            }
            else
            {
                await services.GetService<IProductServices>().DeleteAsync(result);
                return Ok();
            }
        }
    }
}
