using AuthenticationLayer.Hash;
using AuthenticationLayer.Proxy.Abstractions;
using AuthenticationLayer.Token;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using Microsoft.Extensions.Configuration;
using Queries.Declarations.Shared;

namespace AuthenticationLayer.Proxy
{
    public class UserServiceProxy : IUserServiceProxy
    {
        private readonly IUserServices userServices;
        private readonly IMapperConfiguration<UserRegisterModel, UserModel> mapperConfiguration;
        private readonly TokenGenerator tokenGenerator;
        private readonly IMediator mediator;
        public UserServiceProxy(IMediator mediator, IConfiguration configuration, IMapperConfiguration<UserRegisterModel, UserModel> mapperConfiguration, IUserServices userServices)
        {
            this.userServices = userServices;
            this.mapperConfiguration = mapperConfiguration;
            tokenGenerator = new TokenGenerator(configuration);
            this.mediator = mediator;
        }

        public async Task<UserModel> Register(UserRegisterModel userRegisterModel)
        {
            var email = userRegisterModel.Email;
            if (!await userServices.IsExists(o => o.Email.Equals(email)))
            {
                UserModel userModel = mapperConfiguration.ConvertToModel(userRegisterModel);
                userModel.PasswordHash = Hasher.Encrypt(userModel.Password);
                return await userServices.InsertAsync(userModel);
            }
            return null;
        }

        public async Task<string> LogIn(UserLoginModel userLoginModel)
        {
            var PasswordHash = Hasher.Encrypt(userLoginModel.Password);
            if(!await userServices.IsExists(o => o.Email.Equals(userLoginModel.Email)))
            {
                return "";
            }
            var model = await userServices.GetModels(o => o.Email.Equals(userLoginModel.Email)).FirstAsync();
            var roles = await mediator.Send(new GetRoleQuery(model.Id));
            var role = roles.FirstOrDefault();
            return PasswordHash.Equals(model.PasswordHash) ? tokenGenerator.GenerateJSONWebToken(userLoginModel, role) : "";
        }
    }
}
