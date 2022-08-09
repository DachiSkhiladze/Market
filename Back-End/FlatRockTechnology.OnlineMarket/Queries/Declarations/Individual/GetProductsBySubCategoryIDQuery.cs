using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Declarations.Individual
{
    public record GetProductsBySubCategoryIDQuery(Guid subCategoryId) : IRequest<IEnumerable<ProductModel>>;
}
