using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices
{
    public class UserRoleServices : BaseService<UserRole, UserRoleModel>, IUserRoleServices
    {
        private readonly IRoleServices roleServices;
        public UserRoleServices(IMediator mediator, IRoleServices roleServices) : base(mediator)
        {
            this.roleServices = roleServices;
        }

        public async Task<string> GetUserRole(Guid id)
        {
            var userRole = await this.GetSingleModel(o => o.UserId.Equals(id));
            var role = await roleServices.GetSingleModel(o => o.Id.Equals(userRole.Id));
            return role.Title;
        }
    }
}
