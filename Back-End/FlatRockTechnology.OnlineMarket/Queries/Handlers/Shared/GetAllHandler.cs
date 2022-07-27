using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using MediatR;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using Queries.Declarations.Shared;

namespace Queries.Handlers.Shared
{
    public class GetAllHandler<TEntity, TModel> : IRequestHandler<GetRole<TEntity, TModel>, IEnumerable<TModel>> where TEntity : class, new() where TModel : class, new()
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;
        private readonly IMapperConfiguration<TEntity, TModel> _mapperConfiguration;

        public GetAllHandler(IUnitOfWork<TEntity> unitOfWork, IMapperConfiguration<TEntity, TModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }
         
        public async Task<IEnumerable<TModel>> Handle(GetRole<TEntity, TModel> request, CancellationToken cancellationToken)
        {
            return _mapperConfiguration.ConvertToModelsFromList(await _unitOfWork.GetRepository().GetList());
        }
    }
}
