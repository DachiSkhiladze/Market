using MediatR;
namespace Commands.Declarations.Shared
{
    public record CreateCommand<TEntity, TModel>(TModel model) : IRequest<TModel>;
}
