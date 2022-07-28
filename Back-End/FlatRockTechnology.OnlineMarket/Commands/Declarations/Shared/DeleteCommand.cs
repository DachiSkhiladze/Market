using MediatR;
namespace Commands.Declarations.Shared
{
    public record DeleteCommand<TEntity, TModel>(TModel model) : IRequest<bool>;
}
