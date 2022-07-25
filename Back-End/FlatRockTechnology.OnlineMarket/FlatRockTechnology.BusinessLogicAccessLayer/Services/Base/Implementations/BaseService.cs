using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using MediatR;
using Queries.Declarations.Shared;
using System.Linq.Expressions;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations
{
    public abstract class BaseService<TEntity, TModel> : IBaseService<TEntity, TModel>
                                                              where TEntity : class, new()
                                                              where TModel : class, new()
    {
        private readonly IMediator mediator;
        public BaseService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> IsExists(Expression<Func<TEntity, bool>> predicate) => await mediator.Send(new IsExistsQuery<TEntity>(predicate));

        public async Task<IEnumerable<TModel>> GetModels()
        {
            return await mediator.Send(new GetAllQuery<TEntity, TModel>());
        }

        public async IAsyncEnumerable<TModel> GetModels(Expression<Func<TEntity, bool>> predicate)
        {
            return await mediator.Send(new GetQuery<TEntity, TModel>(predicate));
        }

        public async Task<TModel> InsertAsync(TModel model)
        {
            var dto = ConvertToDTO(model);
            return ConvertToModel(await Repository.AddAsync(dto));  // Inserting New Data
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            var dto = ConvertToDTO(model);
            return ConvertToModel(await Repository.UpdateAsync(dto)); // Updating Data
        }

        public async Task DeleteAsync(TModel model)
        {
            var dto = ConvertToDTO(model);
            await Repository.DeleteAsync(dto); // Deleting Data
        }

        protected abstract TEntity ConvertToDTO(TModel model);  // Overloaded in subclasses

        protected abstract TModel ConvertToModel(TEntity entity);  // Overloaded in subclasses

        protected abstract IEnumerable<TModel> ConvertToModels(IQueryable<TEntity> entities);  // Overloaded in subclasses
    }
}
