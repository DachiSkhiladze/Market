using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Models
{
    public class PaymentModel
    {
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public int Month { get; set; }
        public double Year { get; set; }
        public string CVC { get; set; }
        public long Value { get; set; }
    }
}
