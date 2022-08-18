using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataAccessLayer.Models
{
    public class ChatUser
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set; }
        public string ChatNickName { get; set; }
    }
}
