using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Declarations.Individual.Products
{
    public record CreateProductCommand(ProductModel model) : IRequest<ProductModel>;
}
