using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTech.OnlineMarket.BusinessLogicLayer.Mapper.Abstractions
{
    public partial class Read
    {
        public interface IMapperConfiguration<TEntity, TModel> where TEntity : class, new() where TModel : class, new()
        {
            TEntity ConvertToEntity(TModel model);
            TModel ConvertToModel(TEntity entity);
            IEnumerable<TEntity> ConvertToEntities(IEnumerable<TModel> models);
            IEnumerable<TModel> ConvertToModels(IEnumerable<TEntity> models);
            IEnumerable<TModel> ConvertToModelsFromList(List<TEntity> models);
        }
    }
}
