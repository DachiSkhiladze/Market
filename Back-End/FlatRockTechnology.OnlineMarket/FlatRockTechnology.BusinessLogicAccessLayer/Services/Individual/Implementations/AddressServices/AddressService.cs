using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Addresses;
using MediatR;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.AddressServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.AddressServices
{
    public class AddressService : BaseService<Address, AddressModel>, IAddressServices
    {
        public AddressService(IMediator mediator) : base(mediator)
        {

        }
    }
}