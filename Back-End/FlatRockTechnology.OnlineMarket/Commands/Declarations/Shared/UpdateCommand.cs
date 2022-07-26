using MediatR;
namespace Commands.Declarations.Shared
{
    public record UpdateCommand<TEntity, TModel>(TModel model) : IRequest<TModel>;
}
