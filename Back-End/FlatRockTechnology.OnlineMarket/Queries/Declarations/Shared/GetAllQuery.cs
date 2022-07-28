using MediatR;

namespace Queries.Declarations.Shared
{
    public record GetRole<TEntity, TModel> : IRequest<IEnumerable<TModel>>;
}
