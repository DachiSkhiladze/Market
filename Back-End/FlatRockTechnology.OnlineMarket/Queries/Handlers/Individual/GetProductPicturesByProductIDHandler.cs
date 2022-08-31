using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
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
    public class GetProductPicturesByProductIDHandler : IRequestHandler<GetProductPicturesByProductIDQuery, IEnumerable<ProductPicturesModel>>
    {
        private readonly IUnitOfWork<ProductPictures> _unitOfWork;
        private readonly IMapperConfiguration<ProductPictures, ProductPicturesModel> _mapperConfiguration;

        public GetProductPicturesByProductIDHandler(IUnitOfWork<ProductPictures> unitOfWork,
            IMapperConfiguration<ProductPictures, ProductPicturesModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }

        public async Task<IEnumerable<ProductPicturesModel>> Handle(GetProductPicturesByProductIDQuery request, CancellationToken cancellationToken)
        {

            IAsyncEnumerable<ProductPictures> productPictures = _unitOfWork.ProductPictures
                                                    .Get(o => o.ProductId.Equals(request.productId));
            return _mapperConfiguration.ConvertToModelsFromList(productPictures.ToListAsync().Result);
        }
    }
}
