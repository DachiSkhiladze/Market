using MediatR;

namespace Queries.Declarations.Shared
{
    public record GetAllQuery<TEntity, TModel> : IRequest<IEnumerable<TModel>>;
}
