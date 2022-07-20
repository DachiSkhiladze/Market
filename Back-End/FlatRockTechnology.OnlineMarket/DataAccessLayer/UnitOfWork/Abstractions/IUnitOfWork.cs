using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Individual.Abstractions;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class, new()
    {
        IAddressRepository Addresses { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IOrderProductRepository OrderProducts { get; }
        IProductCategoryRepository ProductCategories { get; }
        IProductRepository Products { get; }
        ISubCategoryRepository SubCategories { get; }
        IUserRepository Users { get; }
        IRepository<TEntity> GetRepository();
        int Complete();
    }
}
