using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.Models.Users;
using Microsoft.AspNetCore.Identity;

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
