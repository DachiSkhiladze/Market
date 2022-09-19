using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using Commands.Declarations.Individual.Products;
using MediatR;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;

namespace Commands.Handlers.Write.ProductHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductModel>
    {
        private readonly IUnitOfWork<Product> _unitOfWork;
        private readonly IMapperConfiguration<Product, ProductModel> _mapperConfiguration;

        public UpdateProductHandler(IUnitOfWork<Product> unitOfWork, IMapperConfiguration<Product, ProductModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }

        public async Task<ProductModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product entity = _mapperConfiguration.ConvertToEntity(request.model);
            Product savedEntity = await _unitOfWork.Products.UpdateAsync(entity);
            if (savedEntity == null)
            {
                throw new Exception("No Product Found");
            }
            ProductModel savedModel = _mapperConfiguration.ConvertToModel(savedEntity);
            foreach (var category in request?.model?.Categories ?? new List<Guid>())
            {
                await UpdateProductCategory(category, savedEntity.Id);
            }
            return savedModel;
        }

        public async Task UpdateProductCategory(Guid subCategoryId, Guid productId)
        {
            //Deleting old Record
            var products = _unitOfWork.ProductCategories.Get(o => o.ProductId.Equals(productId));
            foreach (var product in products)
            {
                await _unitOfWork.ProductCategories.DeleteAsync(product);
            }

            //Adding new Record
            ProductCategory productCategory = new ProductCategory()
            {
                SubCategoryId = subCategoryId,
                ProductId = productId
            };
            await _unitOfWork.ProductCategories.AddAsync(productCategory);
        }
    }
}
