using FlatRockTechnology.OnlineMarket.Models.Addresses;
using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Models.Payment
{
    public class PaymentSubmissionModel
    {
        public AddressModel Address { get; set; }
        public PaymentModel PaymentDetails { get; set; }
    }
}
