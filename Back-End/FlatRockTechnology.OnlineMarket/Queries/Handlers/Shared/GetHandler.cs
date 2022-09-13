using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using MediatR;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using Queries.Declarations.Shared;
using System.Runtime.CompilerServices;

namespace Queries.Handlers.Shared
{
    public class GetHandler<TEntity, TModel> : IStreamRequestHandler<GetQuery<TEntity, TModel>, TModel> 
                                                where TEntity : class, new() 
                                                where TModel : class, new()
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;
        private readonly IMapperConfiguration<TEntity, TModel> _mapperConfiguration;

        public GetHandler(IUnitOfWork<TEntity> unitOfWork, IMapperConfiguration<TEntity, TModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }
         
        public async IAsyncEnumerable<TModel> Handle(GetQuery<TEntity, TModel> request,
                                                    [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            foreach (var entity in _unitOfWork.GetRepository().Get(request.predicate))
            {
                yield return _mapperConfiguration.ConvertToModel(entity);
            }
        }
    }
}
