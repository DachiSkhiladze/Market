using FlatRockTechnology.OnlineMarket.Models.Categories;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;

namespace Commands.Declarations.Individual.Products
{
    public record CreateProductCategoryCommand(ProductCategoryModel model) : IRequest<ProductCategoryModel>;
}
