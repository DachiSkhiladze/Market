using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.Models.Users;
using System.Security.Claims;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginModel userLoginModel);
        Task<string> CreateToken();
        Task<User> GetUser(ClaimsPrincipal user);
    }
}