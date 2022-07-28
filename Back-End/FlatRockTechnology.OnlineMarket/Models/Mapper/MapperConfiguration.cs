using AutoMapper;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;

namespace FlatRockTechnology.OnlineMarket.Models.Mapper
{
    public class MapperConfiguration<TEntity, TModel> : IMapperConfiguration<TEntity, TModel> where TEntity : class, new() where TModel : class, new()
    {
        private readonly IMapper _mapper;
        public MapperConfiguration(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TEntity ConvertToEntity(TModel model) => _mapper.Map<TEntity>(model);

        public TModel ConvertToModel(TEntity entity)
        {
                return _mapper.Map<TModel>(entity);
        }

        public IEnumerable<TEntity> ConvertToEntities(IEnumerable<TModel> models)
        {
            foreach (var model in models)
            {
                yield return ConvertToEntity(model);
            }
        }

        public IEnumerable<TModel> ConvertToModels(IEnumerable<TEntity> models)
        {
            foreach (var model in models)
            {
                yield return ConvertToModel(model);
            }
        }

        public IEnumerable<TModel> ConvertToModelsFromList(List<TEntity> models)
        {
            foreach (var model in models)
            {
                yield return ConvertToModel(model);
            }
        }
    }
}
