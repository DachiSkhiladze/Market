using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;

namespace Queries.Declarations.Shared
{
    public class GetRoleHandler : IRequestHandler<GetRoleQuery, IEnumerable<RoleModel>>
    {
        private readonly IUnitOfWork<Role> _unitOfWork;
        private readonly IMapperConfiguration<Role, RoleModel> _mapperConfiguration;

        public GetRoleHandler(IUnitOfWork<Role> unitOfWork, 
            IMapperConfiguration<Role, RoleModel> mapperConfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapperConfiguration = mapperConfiguration;
        }

        public async Task<IEnumerable<RoleModel>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {

            IEnumerable<Guid?> userRoleIds = _unitOfWork.UserRoles.Get(o => o.UserId.Equals(request.userId)).Select(o => o.RoleId);
            if (userRoleIds.Count() == 0) 
            {
                throw new Exception(); 
            }
            IEnumerable<Role> roles = _unitOfWork.Roles.Get((o) => userRoleIds
                                                            .Any(y => y.Equals(o.Id)));
            return _mapperConfiguration.ConvertToModelsFromList(roles.ToList());
        }
    }
}
