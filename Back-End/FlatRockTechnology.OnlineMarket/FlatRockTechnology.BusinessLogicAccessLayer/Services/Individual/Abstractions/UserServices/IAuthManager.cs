using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.User;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginModel userLoginModel);
        Task<string> CreateToken();
        Task<User> GetUser(ClaimsPrincipal user);
    }
}