using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CategoryServices;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.AddressServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CartServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.OrderServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.ProductServices;
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
                                    ICartItemServices,
                                    IProductPicturesServices,
                                    ISubCategoryServices,
                                    ICategoryServices,
                                    IOrderServices,
                                    IAddressServices,
                                    IOrderProductServices,
                                    IRoleServices
        // Inheritence of all services is sacrosanct for using in upper tier layers
    {

    }
}
