using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.User;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices
{
    public interface IUserServices : IBaseService<User, UserModel>
    {
        Task<IdentityResult> Register(UserModel model);
        Task<UserModel> DisableOrEnableUser(string id);
        Task DeleteUserAsync(string id);
        Task<bool> UpdateEmailAsync(string id, string newEmail);
    }
}
