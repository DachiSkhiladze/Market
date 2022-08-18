using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.Models.Chat
{
    public class MessageModel
    {
        public string User { get; set; }
        public string MessageTo { get; set; }
        public string Message { get; set; }
    }
}
