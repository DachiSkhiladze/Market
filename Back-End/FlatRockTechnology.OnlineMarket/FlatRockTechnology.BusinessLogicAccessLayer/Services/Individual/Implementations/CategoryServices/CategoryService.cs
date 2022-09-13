using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CategoryServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Categories;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Queries.Declarations.Individual;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.CategoryServices
{
    public class CategoryService : BaseService<Category, CategoryModel>, ICategoryServices
    {
        public CategoryService(IMediator mediator) : base(mediator)
        {

        }
    }
}
