using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataAccessLayer.Models
{
    public class Message
    {
        internal string Id { get; set; }
        public Guid UserID { get; set; }
        public string MessageText { get; set; }
        public DateTime Time { get; set; }
    }
}
