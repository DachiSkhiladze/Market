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
        [Route("CreateSubCategory")]
        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody]SubCategoryModel categoryModel)
        {
            await servicesFlyweight.GetService<ISubCategoryServices>().InsertAsync(categoryModel);
            return Ok();
        }
        [HttpGet]
        [Route("DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(Guid id)
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
