using AuthenticationLayer.Hash;
using AuthenticationLayer.Proxy.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Users;

namespace AuthenticationLayer.Proxy
{
    public class UserServiceProxy : IUserServiceProxy
    {
        private readonly IUserServices userServices;
        private readonly IMapperConfiguration<UserRegisterModel, UserModel> mapperConfiguration;
        public UserServiceProxy(IMapperConfiguration<UserRegisterModel, UserModel> mapperConfiguration, IUserServices userServices)
        {
            this.userServices = userServices;
            this.mapperConfiguration = mapperConfiguration;
        }

        public async Task<UserModel> Register(UserRegisterModel userRegisterModel)
        {
            UserModel userModel = mapperConfiguration.ConvertToModel(userRegisterModel);
            userModel.PasswordHash = Hasher.Encrypt(userModel.Password);
            return await userServices.InsertAsync(userModel);
        }

        public async Task<bool> LogIn(UserLoginModel userLoginModel)
        {
            var PasswordHash = Hasher.Encrypt(userLoginModel.Password);
            if(!await userServices.IsExists(o => o.Email.Equals(userLoginModel.Email)))
            {
                return false;
            }
            var model = await userServices.GetModels(o => o.Email.Equals(userLoginModel.Email)).FirstAsync();
            return PasswordHash.Equals(model.PasswordHash);
        }
    }
}
