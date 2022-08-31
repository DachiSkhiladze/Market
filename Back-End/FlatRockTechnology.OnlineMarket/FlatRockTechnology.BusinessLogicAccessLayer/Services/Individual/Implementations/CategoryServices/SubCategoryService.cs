using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Categories;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Queries.Declarations.Individual;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.CategoryServices
{
    public class SubCategoryService : BaseService<SubCategory, SubCategoryModel>, ISubCategoryServices
    {
        public SubCategoryService(IMediator mediator) : base(mediator)
        {

        }
    }
}
