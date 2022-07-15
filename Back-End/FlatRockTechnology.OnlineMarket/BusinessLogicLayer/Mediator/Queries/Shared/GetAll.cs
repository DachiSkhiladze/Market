using MediatR;

namespace FlatRockTech.OnlineMarket.BusinessLogicLayer.Queries
{
    public partial class Read
    {
        public record GetAll<TEntity, TModel> : IRequest<IEnumerable<TModel>>;
    }
}
