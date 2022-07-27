using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Individual.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Individual.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Implementations
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class, new()
    {
        private readonly MarketContext _context;
        private readonly IRepository<TEntity> _repository;
        public UnitOfWork(MarketContext context, IRepository<TEntity> repository)
        {
            _context = context;
            _repository = repository;
            Addresses = new AddressRepository(_context);
            Categories = new CategoryRepository(_context);
            Orders = new OrderRepository(_context);
            OrderProducts = new OrderProductRepository(_context);
            ProductCategories = new ProductCategoryRepository(_context);
            Products = new ProductRepository(_context);
            SubCategories = new SubCategoryRepository(_context);
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            UserRoles = new UserRoleRepository(_context);
        }
        public IRepository<TEntity> GetRepository()
        {
            return _repository;
        }

        public IUserRoleRepository UserRoles { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IAddressRepository Addresses { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderProductRepository OrderProducts { get; private set; }

        public IProductCategoryRepository ProductCategories { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISubCategoryRepository SubCategories { get; private set; }

        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
