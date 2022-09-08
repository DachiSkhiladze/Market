using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using EmailLayer.Abstractions;
using FlatRockTechnology.OnlineMarket.Models;
using FlatRockTechnology.OnlineMarket.Models.Hash;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices
{
    public class UserServices : BaseService<User, UserModel>, IUserServices
    {
        private readonly IEmailSender emailSender;
        public UserServices(IMediator mediator, IEmailSender emailSender) : base(mediator)
        {
            this.emailSender = emailSender;
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
                var models = await GetModels();
                var model = models.FirstOrDefault(o => o.Email.Equals(email));
                if (model != null)
                {
                    var code = emailSender.SendRecovery(email, model.FirstName, model.LastName, origin);
                    model.PasswordRecoveryCode = code;
                    await UpdateAsync(model);
                    return true;
                }
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
