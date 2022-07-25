using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using Commands.Declarations.Individual.Products;
using MediatR;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;

namespace Commands.Handlers.Write.ProductHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductModel>
    {
        private readonly IUnitOfWork<Product> _unitOfWork;
        private readonly IMapperConfiguration<Product, ProductModel> _mapperConfiguration;

        public CreateProductHandler(IUnitOfWork<Product> unitOfWork, IMapperConfiguration<Product, ProductModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }

        public async Task<ProductModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product entity = _mapperConfiguration.ConvertToEntity(request.model);
            Product savedEntity = await _unitOfWork.Products.AddAsync(entity);
            ProductModel savedModel = _mapperConfiguration.ConvertToModel(savedEntity); 
            foreach (var category in request.model.Categories)
            {
                await CreateProductCategory(category, savedEntity.Id);
            }
            return savedModel;
        }

        public async Task CreateProductCategory(Guid subCategoryId, Guid productId)
        {
            ProductCategory productCategory = new ProductCategory()
            {
                SubCategoryId = subCategoryId,
                ProductId = productId
            };
            await _unitOfWork.ProductCategories.AddAsync(productCategory);
        }
    }
}
