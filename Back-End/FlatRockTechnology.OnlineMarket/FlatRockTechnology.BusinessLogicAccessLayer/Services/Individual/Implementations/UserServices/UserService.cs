using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using EmailLayer.Abstractions;
using FlatRockTechnology.OnlineMarket.Models;
using FlatRockTechnology.OnlineMarket.Models.Hash;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices
{
    public class UserServices : BaseService<User, UserModel>, IUserServices
    {
        private readonly IEmailSender emailSender;
        private readonly IRoleServices roleServices;
        private readonly IUserRoleServices userRoleServices;
        public UserServices(IMediator mediator, IEmailSender emailSender, IRoleServices roleServices, IUserRoleServices userRoleServices) : base(mediator)
        {
            this.emailSender = emailSender;
            this.roleServices = roleServices;
            this.userRoleServices = userRoleServices;
        }

        public async IAsyncEnumerable<UserModel> GetUsersWithRoles()
        {
            var users = await this.GetModels();
            foreach (var user in users)
            {
                user.Role = await userRoleServices.GetUserRole(user.Id);
                yield return user;
            }
        }

        public async Task<bool> UpdateRole(Guid guid, string role)
        {
            var userRoleEntity = await userRoleServices.GetSingleModel(o => o.UserId.Equals(guid));
            var roleEntity = await roleServices.GetSingleModel(o => o.Title.Equals(role));
            userRoleEntity.RoleId = roleEntity.Id;

            await userRoleServices.UpdateAsync(userRoleEntity);

            return true;
        }

        public async Task<bool> ConfirmEmail(string? code)
        {
            var models = await GetModels();
            var model = models.FirstOrDefault(o => o.EmailVerificationCode.Equals(code));
            if (model != null)
            {
                model.IsEmailConfirmed = true;
                await UpdateAsync(model);
                return true;
            }
            return false;
        }

        public async Task<bool> RecoverPassword(string email, string origin)
        {
            if (await IsExists(o => o.Email.Equals(email)))
            {
                var model = await GetSingleModel(o => o.Email.Equals(email));
                var code = emailSender.SendRecovery(email, model.FirstName, model.LastName, origin);
                model.PasswordRecoveryCode = code;
                await UpdateAsync(model);
                return true;
                return false;
            }
            return false;
        }

        public async Task<bool> RecoverPassword(ForgotPasswordModel passwordModel)
        {
            if (await IsExists(o => o.PasswordRecoveryCode == null ? false : o.PasswordRecoveryCode.Equals(passwordModel.code)))
            {
                var models = await GetModels();
                var model = models.FirstOrDefault(o => o.PasswordRecoveryCode == null ? false : o.PasswordRecoveryCode.Equals(passwordModel.code));
                if (model != null)
                {
                    model.PasswordHash = Hasher.Encrypt(passwordModel.password);
                    await UpdateAsync(model);
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
