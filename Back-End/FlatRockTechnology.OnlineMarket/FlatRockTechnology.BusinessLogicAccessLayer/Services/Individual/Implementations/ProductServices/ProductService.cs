using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.ProductServices
{
    public class ProductServices : BaseService<Product, ProductModel>, IProductServices
    {
        public ProductServices(IMediator mediator) : base(mediator)
        {

        }
    }
}
