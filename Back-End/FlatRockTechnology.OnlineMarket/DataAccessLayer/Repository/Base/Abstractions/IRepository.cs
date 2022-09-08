using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        bool IsExists(Expression<Func<TEntity, bool>> predicate);

        long GetCount();

        IQueryable<TEntity> GetAll();

        Task<List<TEntity>> GetList();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        IQueryable<TEntity> Get(int skip, int take);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);
    }
}
