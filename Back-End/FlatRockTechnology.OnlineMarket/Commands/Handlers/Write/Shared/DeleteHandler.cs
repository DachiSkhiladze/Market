using Commands.Declarations.Shared;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using MediatR;

namespace Commands.Handlers.Write.Shared
{
    public class DeleteHandler<TEntity, TModel> : IRequestHandler<DeleteCommand<TEntity, TModel>, bool> where TEntity : class, new() where TModel : class, new()
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;
        private readonly IMapperConfiguration<TEntity, TModel> _mapperConfiguration;

        public DeleteHandler(IUnitOfWork<TEntity> unitOfWork, IMapperConfiguration<TEntity, TModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }

        public async Task<bool> Handle(DeleteCommand<TEntity, TModel> request, CancellationToken cancellationToken)
        {
            var entity = _mapperConfiguration.ConvertToEntity(request.model);
            return await _unitOfWork.GetRepository().DeleteAsync(entity);
        }
    }
}
