using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailLayer.Abstractions
{
    public interface IEmailSender
    {
        public string Send(string Email, string FirstName, string LastName);
    }
}
