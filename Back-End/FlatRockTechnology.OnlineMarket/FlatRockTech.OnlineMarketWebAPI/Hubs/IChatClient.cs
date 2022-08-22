using ChatDataAccessLayer.Models;
using FlatRockTechnology.OnlineMarket.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTech.OnlineMarketWebAPI.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(MessageModel message);
    }
}
