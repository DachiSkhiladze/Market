using Commands.Declarations.Shared;
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

        public async IAsyncEnumerable<TModel> GetModels()
        {
            await foreach (var model in 
                (await mediator.Send(new GetAllQuery<TEntity, TModel>())).ToAsyncEnumerable())
            {
                yield return model;
            }
        }

        public IAsyncEnumerable<TModel> GetModels(Expression<Func<TEntity, bool>> predicate)
        {
            return mediator.CreateStream(new GetQuery<TEntity, TModel>(predicate));
        }
        
        public async Task<TModel> InsertAsync(TModel model)
        {
            return await mediator.Send(new CreateCommand<TEntity, TModel>(model));// Inserting New Data
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            return await mediator.Send(new UpdateCommand<TEntity, TModel>(model));// Updating Data
        }

        public async Task<bool> DeleteAsync(TModel model)
        {
            return await mediator.Send(new DeleteCommand<TEntity, TModel>(model)); // Deleting Data
        }
    }
}
