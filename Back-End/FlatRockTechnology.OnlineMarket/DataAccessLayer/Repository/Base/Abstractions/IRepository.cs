using System.Linq.Expressions;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        bool IsExists(Expression<Func<TEntity, bool>> predicate);

        long GetCount();

        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetList();

        IAsyncEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Get(int skip, int take);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
