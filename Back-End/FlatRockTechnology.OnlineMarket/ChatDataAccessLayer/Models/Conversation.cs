using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataAccessLayer.Models
{
    public class Conversation
    {
        [Key]
        public string Id { get; set; }
        public List<ChatUser> Participants { get; set; }
        public List<Message> Messages { get; set; }
        public int TotalMessagees { get; set; }
        public DateTime Time { get; set; }
    }
}
