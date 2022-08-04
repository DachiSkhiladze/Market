using AuthenticationLayer.Proxy.Abstractions;
using AuthenticationLayer.Token;
using EmailLayer.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.Models.Hash;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using Microsoft.Extensions.Configuration;
using Queries.Declarations.Shared;

namespace AuthenticationLayer.Proxy
{
    public class UserServiceProxy : IUserServiceProxy
    {
        private readonly IMapperConfiguration<UserRegisterModel, UserModel> mapperConfiguration;
        private readonly TokenGenerator tokenGenerator;
        private readonly IMediator mediator;
        private readonly IEmailSender emailSender;
        private readonly IServicesFactory servicesFactory;
        public UserServiceProxy(IEmailSender emailSender, IMediator mediator, IConfiguration configuration, IMapperConfiguration<UserRegisterModel, UserModel> mapperConfiguration, IServicesFactory servicesFactory)
        {
            this.mapperConfiguration = mapperConfiguration;
            tokenGenerator = new TokenGenerator(configuration);
            this.mediator = mediator;
            this.emailSender = emailSender;
            this.servicesFactory = servicesFactory;
        }

        public async Task<UserModel> Register(UserRegisterModel userRegisterModel, string origin)
        {
            var email = userRegisterModel.Email;

            if (!await servicesFactory.GetService<IUserServices>().IsExists(o => o.Email.Equals(email)))
            {
                UserModel userModel = mapperConfiguration.ConvertToModel(userRegisterModel);
                userModel.PasswordHash = Hasher.Encrypt(userModel.Password);
                var code = emailSender.Send(userModel.Email, userModel.FirstName, userModel.LastName, origin);
                userModel.EmailVerificationCode = code;
                userModel.IsEmailConfirmed = false;
                var insertedModel = await servicesFactory.GetService<IUserServices>().InsertAsync(userModel);
                var userRoleModel = new UserRoleModel()
                {
                    UserId = insertedModel.Id,
                    RoleId = Guid.Parse("9A5411FD-7029-45CE-9880-0E96EF8EE33A") // User Role ID
                };
                await servicesFactory.GetService<IUserRoleServices>().InsertAsync(userRoleModel);
                return insertedModel;
            }
            return null;
        }

        public async Task<string> LogIn(UserLoginModel userLoginModel)
        {
            var PasswordHash = Hasher.Encrypt(userLoginModel.Password);
            var model = await servicesFactory.GetService<IUserServices>().GetModels(o => o.Email.Equals(userLoginModel.Email)).FirstOrDefaultAsync();
            if (model == null)
            {
                return "";
            }
            if (model.IsEmailConfirmed == false)
            {
                return "";
            }
            var roles = await mediator.Send(new GetRoleQuery(model.Id));
            var role = roles.FirstOrDefault();
            return PasswordHash.Equals(model.PasswordHash) ? tokenGenerator.GenerateJSONWebToken(userLoginModel, role) : "";
        }
    }
}
