using Commands.Declarations.Shared;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using MediatR;

namespace Commands.Handlers.Write.Shared
{
    public class CreateHandler<TEntity, TModel> : IRequestHandler<CreateCommand<TEntity, TModel>, TModel> 
                                                    where TEntity : class, new() 
                                                     where TModel : class, new()
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;
        private readonly IMapperConfiguration<TEntity, TModel> _mapperConfiguration;

        public CreateHandler(IUnitOfWork<TEntity> unitOfWork, 
                              IMapperConfiguration<TEntity, TModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }

        public async Task<TModel> Handle(CreateCommand<TEntity, TModel> request, 
                                          CancellationToken cancellationToken)
        {
            var entity = _mapperConfiguration.ConvertToEntity(request.model);
            var savedEntity = await _unitOfWork.GetRepository().AddAsync(entity);
            var savedModel = _mapperConfiguration.ConvertToModel(savedEntity);
            return savedModel;
        }
    }
}
