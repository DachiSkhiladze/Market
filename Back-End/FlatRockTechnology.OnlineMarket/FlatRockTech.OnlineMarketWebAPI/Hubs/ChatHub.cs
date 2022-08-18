using ChatDataAccessLayer.Data;
using ChatDataAccessLayer.Models;
using ChatDataAccessLayer.Repo;
using FlatRockTechnology.OnlineMarket.Models.Chat;
using MediatR;
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
        CosmosRepository chatRepository;

        public ChatHub(IMediator mediator)
        {
            chatRepository = new CosmosRepository(new ChatContext(), mediator);
        }

        public async Task SendMessage(MessageModel message)
        {
            await Clients.All.ReceiveMessage(message);
            message.User = Context.User.FindFirst(ClaimTypes.Email).Value;
            await chatRepository.InsertMessageAsync(message);
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
