using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Extensions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly MarketContext _marketContext;
        static readonly object _object = new object();
        public Repository(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public bool IsExists(Expression<Func<TEntity, bool>> predicate) => this.GetAll().Any(predicate.Compile());

        public long GetCount() => this.GetAll().Count();

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _marketContext.Set<TEntity>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not be returned: {ex.Message}");
            }
        }

        public async Task<List<TEntity>> GetList()
        {
            try
            {
                return await _marketContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not be returned: {ex.Message}");
            }
        }

        public IQueryable<TEntity> Get(int skip, int take)
        {
            try
            {
                return _marketContext.Set<TEntity>().AsNoTracking().Skip(skip).Take(take);
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not be returned: {ex.Message}");
            }
        }

        public IAsyncEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _marketContext.Set<TEntity>()
                                     .AsQueryable()
                                     .AsNoTracking()
                                     .Where(predicate.Compile())
                                     .ToAsyncEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not be returned: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                entity.ConfigureEntityForAdding();
                var result = await _marketContext.AddAsync(entity);
                await _marketContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.InnerException}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _marketContext.Update(entity);
                _marketContext.Entry<TEntity>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _marketContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _marketContext.Remove(entity);
                _marketContext.Entry<TEntity>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _marketContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
                return false;
            }
        }
    }
}
