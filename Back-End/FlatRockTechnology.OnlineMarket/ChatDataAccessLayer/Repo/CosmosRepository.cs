using ChatDataAccessLayer.Data;
using ChatDataAccessLayer.Models;
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
        public CosmosRepository(ChatContext chatDB)
        {
            this.chatDB = chatDB;
        }

        public async Task Insert(Conversation conversation)
        {
            chatDB.Conversations?.Add(conversation);

            await chatDB.SaveChangesAsync();
        }

        public async Task InsertMessage(Message message, string conversationId)
        {
            var conversation = chatDB.Conversations?.First(o => o.Id.Equals(conversationId));

            conversation?.Messages?.Add(message);

            chatDB.Conversations?.Update(conversation);

            await chatDB.SaveChangesAsync();
        }

        public IEnumerable<Conversation> GetAll()
        {
            return chatDB.Conversations;
        }
    }
}
