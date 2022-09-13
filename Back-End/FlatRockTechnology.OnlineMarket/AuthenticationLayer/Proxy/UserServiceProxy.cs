using AuthenticationLayer.Proxy.Abstractions;
using AuthenticationLayer.Token;
using AuthenticationLayer.Token.Redis;
using EmailLayer.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models;
using FlatRockTechnology.OnlineMarket.Models.Hash;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Redis;
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
        private readonly RedisDB redisDB;
        private readonly IEmailSender emailSender;
        private readonly IServicesFlyweight servicesFactory;
        public UserServiceProxy(IEmailSender emailSender, IMediator mediator, IConfiguration configuration, IMapperConfiguration<UserRegisterModel, UserModel> mapperConfiguration, IServicesFlyweight servicesFactory)
        {
            this.mapperConfiguration = mapperConfiguration;
            tokenGenerator = new TokenGenerator(configuration);
            this.mediator = mediator;
            this.emailSender = emailSender;
            this.servicesFactory = servicesFactory;
            this.redisDB = new RedisDB();
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
                userModel.IsEmailConfirmed = true;
                var insertedModel = await servicesFactory.GetService<IUserServices>().InsertAsync(userModel);
                var userRoleModel = new UserRoleModel()
                {
                    UserId = insertedModel.Id,
                    RoleId = await GetUserRoleToken() // User Role ID
                };
                await servicesFactory.GetService<IUserRoleServices>().InsertAsync(userRoleModel);
                return insertedModel;
            }
            return null;
        }

        public async Task<Guid> GetUserRoleToken()
        {
            var role = await mediator.Send(new GetSingleQuery<Role, RoleModel>(o => o.NormalizedName.Equals("USER")));
            return role.Id;
        }

        public async Task<AuthenticatedResponseModel> LogIn(UserLoginModel userLoginModel)
        {
            Tuple<Guid, bool> isValid = await CheckUserCredentialsValidity(userLoginModel);
            var userId = isValid.Item1;
            if (!isValid.Item2)
            {
                return new AuthenticatedResponseModel();
            }
            else
            {
                var role = await GetRoleModel(isValid.Item1);
                var token = GetToken(userLoginModel.Email, role);
                var redisModel = new RedisTokenValueModel()
                {
                    UserId = userId,
                    AccessToken = token.AccessToken
                };
                await redisDB.InsertAsync(token.RefreshToken, redisModel); // implement
                return token;
            }
        }

        public async Task<AuthenticatedResponseModel> Refresh(string refreshToken)
        {
            var redisResult = await redisDB.GetAsync(refreshToken);
            if (redisResult != null)
            {
                await redisDB.DeleteAsync(refreshToken);
                string userEmail = tokenGenerator.getJWTTokenClaim(redisResult.AccessToken, "Email");
                UserModel userModel = await servicesFactory.GetService<IUserServices>().GetModels(o => o.Email.Equals(userEmail)).FirstOrDefaultAsync();
                var userRole = await GetRoleModel(userModel.Id);
                AuthenticatedResponseModel tokenModel = GetToken(userEmail, userRole);

                RedisTokenValueModel redisModel = new RedisTokenValueModel()
                {
                    UserId = userModel.Id,
                    AccessToken = tokenModel.AccessToken
                };

                await redisDB.InsertAsync(tokenModel.RefreshToken, redisModel);

                return tokenModel;
            }
            return new AuthenticatedResponseModel();
        } 

        private AuthenticatedResponseModel GetToken(string email, RoleModel role)
        {
            var tokenModel = new AuthenticatedResponseModel();
            tokenModel.AccessToken = tokenGenerator.GenerateJSONWebToken(email, role);
            tokenModel.RefreshToken = tokenGenerator.GenerateRefreshToken();
            return tokenModel;
        }

        private async Task<RoleModel> GetRoleModel(Guid userId)
        {
            var roles = await mediator.Send(new GetRoleQuery(userId));
            var role = roles.FirstOrDefault();
            return role;
        }

        private async Task<Tuple<Guid, bool>> CheckUserCredentialsValidity(UserLoginModel userLoginModel)
        {

            var PasswordHash = Hasher.Encrypt(userLoginModel.Password);
            var model = await servicesFactory.GetService<IUserServices>().GetModels(o => o.Email.Equals(userLoginModel.Email)).FirstOrDefaultAsync();
            if (model == null /*|| model.IsEmailConfirmed == false*/ || !PasswordHash.Equals(model.PasswordHash))
            {
                throw new Exception("Invalid Credentials");
            }

            return new Tuple<Guid, bool>(model.Id, true);
        }
    }
}
