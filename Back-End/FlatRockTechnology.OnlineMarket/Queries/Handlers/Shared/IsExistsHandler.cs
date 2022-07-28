using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using MediatR;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using Queries.Declarations.Shared;

namespace Queries.Handlers.Shared
{
    public class IsExistsHandler<TEntity, TModel> : IRequestHandler<IsExistsQuery<TEntity>, bool> where TEntity : class, new() where TModel : class, new()
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;
        private readonly IMapperConfiguration<TEntity, TModel> _mapperConfiguration;

        public IsExistsHandler(IUnitOfWork<TEntity> unitOfWork, IMapperConfiguration<TEntity, TModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }
         
        public async Task<bool> Handle(IsExistsQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _unitOfWork.GetRepository().IsExists(request.predicate));
        }
    }
}
