using ChatDataAccessLayer.Data;
using ChatDataAccessLayer.Models;
using ChatDataAccessLayer.Repo;
using FlatRockTech.OnlineMarketWebAPI.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;

        public ChatController(IHubContext<ChatHub, IChatClient> chatHub)
        {
            _chatHub = chatHub;
        }

        CosmosRepository chatRepository = new CosmosRepository(new ChatContext());
        [Route("CreateConversation")]
        [HttpGet]
        public async Task<IActionResult> CreateConversation([FromBody] Conversation conversation)
        {
            await chatRepository.Insert(conversation);
            return Ok();
        }

        [HttpPost("ConnectToChat")]
        public async Task ConnectToChat(ChatMessage message)
        {
            // run some logic...
            await _chatHub.Clients.All.ReceiveMessage(message);
        }

        [HttpPost("messages")]
        public async Task Post(ChatMessage message)
        {
            // run some logic...
            
            await _chatHub.Clients.All.ReceiveMessage(message);
        }

        [Route("GetConversation")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(chatRepository.GetAll());
        }
    }
}
