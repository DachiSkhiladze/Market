using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using MediatR;
using Queries.Declarations.Shared;

namespace Queries.Handlers.Shared
{
    public class IsExistsHandler<TEntity, TModel> : IRequestHandler<IsExistsQuery<TEntity>, bool> where TEntity : class, new() where TModel : class, new()
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;

        public IsExistsHandler(IUnitOfWork<TEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
         
        public async Task<bool> Handle(IsExistsQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _unitOfWork.GetRepository().IsExists(request.predicate));
        }
    }
}
