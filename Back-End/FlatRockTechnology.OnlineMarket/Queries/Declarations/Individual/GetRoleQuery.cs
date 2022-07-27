using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;

namespace Queries.Declarations.Shared
{
    public record GetRoleQuery(Guid userId) : IRequest<IEnumerable<RoleModel>>;
}
