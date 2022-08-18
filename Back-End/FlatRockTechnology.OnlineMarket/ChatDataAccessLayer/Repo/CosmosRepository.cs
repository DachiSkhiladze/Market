using ChatDataAccessLayer.Data;
using ChatDataAccessLayer.Models;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Chat;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;
using Queries.Declarations.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataAccessLayer.Repo
{
    public class CosmosRepository
    {
        public ChatContext chatDB;
        private readonly IMediator mediator;
        public CosmosRepository(ChatContext chatDB, IMediator mediator)
        {
            this.chatDB = chatDB;
            this.mediator = mediator;
        }

        private async Task CreateNewConversation(MessageModel model)
        {
            var sender = await mediator.Send(new GetSingleQuery<User, UserModel>(o => o.Email.Equals(model.User)));
            var receiver = await mediator.Send(new GetSingleQuery<User, UserModel>(o => o.Email.Equals(model.MessageTo)));

            var mess = GetMessage(model);

            var conversation = new Conversation()
            {
                Id = new Guid().ToString(),
                Messages = new List<Message> { mess },
                Participants = new List<ChatUser> { new ChatUser() { ChatNickName = null, FirstName = sender.FirstName, LastName = sender.LastName, Email = sender.Email },
                                        new ChatUser() {ChatNickName = null, FirstName = receiver.FirstName, LastName = receiver.LastName, Email = receiver.Email } },
                Time = DateTime.Now,
                TotalMessagees = 1
            };

            chatDB.Conversations?.Add(conversation);

            await chatDB.SaveChangesAsync();
        }

        private Message GetMessage(MessageModel model)
        {
            var message = new Message()
            {
                Id = new Guid().ToString(),
                Time = DateTime.Now,
                MessageText = model.Message,
                UserEmail = model.User
            };
            return message;
        }

        public async Task InsertMessageAsync(MessageModel messageModel)
        {
            var message = new Message() { 
                Id = new Guid().ToString(),
                Time = DateTime.Now,
                MessageText = messageModel.Message,
                UserEmail = messageModel.User
            };

            var db = chatDB.Conversations?.Where(o => o.Participants.Select(o => o.Email).Contains(messageModel.User));
            var ds = db.Where(o => o.Participants.Select(o => o.Email).Contains(messageModel.MessageTo));
            var bubu = "";
            if(ds.Count() == 0)
            {
                await CreateNewConversation(messageModel);
            }
            else
            {
                var conv = ds.First();
                conv.Messages.Add(message);
                conv.TotalMessagees += 1;

                chatDB.Conversations?.Update(conv);

                await chatDB.SaveChangesAsync();
            }
        }

        public IEnumerable<Conversation> GetAll()
        {
            return chatDB.Conversations;
        }
    }
}
