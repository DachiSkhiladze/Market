using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CategoryServices;
using FlatRockTechnology.OnlineMarket.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServicesFlyweight servicesFlyweight;
        public CategoryController(IServicesFlyweight servicesFactory)
        {
            this.servicesFlyweight = servicesFactory;
        }

        [Authorize(Roles = "Administrator")]
        [Route("CreateCategory")]
        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody]CategoryModel categoryModel)
        {
            await servicesFlyweight.GetService<ICategoryServices>().InsertAsync(categoryModel);
            return Ok();
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("DeleteCategory/{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var cat = await servicesFlyweight.GetService<ICategoryServices>().GetModels(o => o.Id.Equals(id)).FirstOrDefaultAsync();
            if(cat == null)
            {
                return BadRequest();
            }
            await servicesFlyweight.GetService<ICategoryServices>().DeleteAsync(cat);
            return Ok();
        }
    }
}
