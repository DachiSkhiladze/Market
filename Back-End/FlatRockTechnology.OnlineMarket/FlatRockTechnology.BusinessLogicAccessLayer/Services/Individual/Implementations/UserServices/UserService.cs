using AutoMapper;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices
{
    public class UserServices : BaseService<User, UserModel>, IUserServices
    {
        public UserServices(IMediator mediator) : base(mediator)
        {

        }
    }
}
