using MediatR;

namespace Queries.Declarations.Shared
{
    public record GetSingleQuery<TEntity, TModel>(Func<TEntity, bool> predicate) : IRequest<TModel>;
}
