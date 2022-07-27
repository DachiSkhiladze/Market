using FlatRockTechnology.OnlineMarket.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLayer.Proxy.Abstractions
{
    public interface IUserServiceProxy
    {
        public Task<UserModel> Register(UserRegisterModel userRegisterModel);
        public Task<string> LogIn(UserLoginModel userLoginModel);
    }
}
