using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions
{
    public interface IFlyWeight :   IUserServices, 
                                    IProductServices,
                                    IUserRoleServices, 
                                    ICartItemServices // Inheritence of all services is sacrosanct for using in upper tier layers
    {
    }
}
