using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.Models.Redis
{
    public class RedisTokenValueModel
    {
        public Guid UserId { get; set; }
        public string AccessToken { get; set; }
    }
}
