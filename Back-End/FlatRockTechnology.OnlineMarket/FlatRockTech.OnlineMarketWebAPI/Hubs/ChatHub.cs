using ChatDataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTech.OnlineMarketWebAPI.Hubs
{
    [Authorize(Roles = "Administrator")]
    public class ChatHub : Hub<IChatClient>
    {
        private Dictionary<Guid, string> connectedUsers = new Dictionary<Guid, string>();

        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }
        public async override Task OnConnectedAsync()
        {
            var bubu = Context.User.Claims;
            var dachi = 1;
        }

        public string GetConnectionId() => Context.ConnectionId;

        public void Subscribe()
        {
            var id = Context.ConnectionId.ToString();
        }
    }
}
