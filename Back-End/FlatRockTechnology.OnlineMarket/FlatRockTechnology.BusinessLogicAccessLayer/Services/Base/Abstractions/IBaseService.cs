using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions
{
    public interface IBaseService
    {

    }

    public interface IBaseService<TEntity, TModel> : IBaseService
    {
        Task<bool> IsExists(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TModel>> GetModels();
        IAsyncEnumerable<TModel> GetModels(Func<TEntity, bool> predicate);
        Task<TModel> InsertAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        Task<bool> DeleteAsync(TModel model);
    }
}
