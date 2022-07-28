using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices
{
    public interface IUserRoleServices : IBaseService<UserRole, UserRoleModel>
    {
    }
}
