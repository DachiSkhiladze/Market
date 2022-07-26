using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions
{
    public interface IFlyWeight : IUserServices // Should inherit all possible services
    {
    }
}
