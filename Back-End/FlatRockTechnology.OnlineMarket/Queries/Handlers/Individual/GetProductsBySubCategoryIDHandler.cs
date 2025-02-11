﻿using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Products;
using MediatR;
using Queries.Declarations.Individual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Handlers.Individual
{
    public class GetProductsBySubCategoryIDHandler : IRequestHandler<GetProductsBySubCategoryIDQuery, IEnumerable<ProductModel>>
    {
        private readonly IUnitOfWork<Product> _unitOfWork;
        private readonly IMapperConfiguration<Product, ProductModel> _mapperConfiguration;

        public GetProductsBySubCategoryIDHandler(IUnitOfWork<Product> unitOfWork,
            IMapperConfiguration<Product, ProductModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetProductsBySubCategoryIDQuery request, CancellationToken cancellationToken)
        {

            IEnumerable<Guid?> productIds = _unitOfWork.ProductCategories
                                                    .Get(o => o.SubCategoryId.Equals(request.subCategoryId))
                                                    .Select(o => o.ProductId);
            if (productIds.Count() == 0)
            {
                throw new Exception();
            }
            IEnumerable<Product> products = _unitOfWork.Products.Get((o) => productIds
                                                            .Any(y => y.Equals(o.Id)));
            return _mapperConfiguration.ConvertToModelsFromList(products.ToList());
        }
    }
}
