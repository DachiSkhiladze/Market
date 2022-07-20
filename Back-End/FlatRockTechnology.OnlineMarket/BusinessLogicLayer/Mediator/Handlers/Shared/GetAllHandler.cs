using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using MediatR;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Queries;
using static FlatRockTech.OnlineMarket.BusinessLogicLayer.Mapper.Abstractions.Read;

namespace FlatRockTech.OnlineMarket.BusinessLogicLayer.Handlers
{
    public partial class Read
    {
        public class GetAllHandler<TEntity, TModel> : IRequestHandler<Queries.Read.GetAll<TEntity, TModel>, IEnumerable<TModel>> where TEntity : class, new() where TModel : class, new()
        {
            private readonly IUnitOfWork<TEntity> _unitOfWork;
            private readonly IMapperConfiguration<TEntity, TModel> _mapperConfiguration;

            public GetAllHandler(IUnitOfWork<TEntity> unitOfWork, IMapperConfiguration<TEntity, TModel> mapperConfiguration)
            {
                _unitOfWork = unitOfWork;
                _mapperConfiguration = mapperConfiguration;
            }

            public async Task<IEnumerable<TModel>> Handle(Queries.Read.GetAll<TEntity, TModel> request, CancellationToken cancellationToken)
            {
                return _mapperConfiguration.ConvertToModelsFromList(await _unitOfWork.GetRepository().GetList());
            }
        }
    }
}
