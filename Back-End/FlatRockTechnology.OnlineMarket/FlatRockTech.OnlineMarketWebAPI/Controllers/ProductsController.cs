using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Categories;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Queries.Declarations.Individual;
using Queries.Declarations.Shared;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
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
            return Ok(await mediator.Send(new GetProductsBySubCategoryIDQuery(id)));
        }

        [Route("GetCategories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await mediator.Send(new GetAllQuery<Category, CategoryModel>()));
        }

        //[Authorize(Roles = "Administrator")]
        [Route("GetCategories/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCategories(Guid id)
        {
            var cat = (IEnumerable<SubCategoryModel>)(await mediator.Send(new GetAllQuery<SubCategory, SubCategoryModel>()));
            return Ok(cat.Where(o => o.CategoryId.Equals(id)));
        }
    }
}
