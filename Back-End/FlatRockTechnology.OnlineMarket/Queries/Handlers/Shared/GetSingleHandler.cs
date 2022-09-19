using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using MediatR;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using Queries.Declarations.Shared;

namespace Queries.Handlers.Shared
{
    public class GetSingleHandler<TEntity, TModel> : IRequestHandler<GetSingleQuery<TEntity, TModel>, TModel> where TEntity : class, new() where TModel : class, new()
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;
        private readonly IMapperConfiguration<TEntity, TModel> _mapperConfiguration;

        public GetSingleHandler(IUnitOfWork<TEntity> unitOfWork, IMapperConfiguration<TEntity, TModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }
         
        public async Task<TModel> Handle(GetSingleQuery<TEntity, TModel> request, CancellationToken cancellationToken)
        {
            var entity = _unitOfWork.GetRepository().GetSingle(request.predicate);
            return _mapperConfiguration.ConvertToModel(entity);
        }
    }
}
