using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CategoryServices;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.Models.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IServicesFlyweight servicesFlyweight;
        public SubCategoryController(IServicesFlyweight servicesFactory)
        {
            this.servicesFlyweight = servicesFactory;
        }
        [HttpGet]
        [Route("GetSubCategories")]
        public async Task<ActionResult> GetSubCategories(Guid id)
        {
            var cat = await servicesFlyweight.GetService<ISubCategoryServices>().GetModels();
            return Ok(cat);
        }
        [Route("CreateSubCategory")]
        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody]SubCategoryModel categoryModel)
        {
            await servicesFlyweight.GetService<ISubCategoryServices>().InsertAsync(categoryModel);
            return Ok();
        }
        [HttpGet]
        [Route("DeleteSubCategory/{id}")]
        public async Task<ActionResult> DeleteSubCategory(Guid id)
        {
            var cat = await servicesFlyweight.GetService<ISubCategoryServices>().GetModels(o => o.Id.Equals(id)).FirstOrDefaultAsync();
            if(cat == null)
            {
                return BadRequest();
            }
            await servicesFlyweight.GetService<ISubCategoryServices>().DeleteAsync(cat);
            return Ok();
        }
    }
}
