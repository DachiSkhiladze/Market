using ChatDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataAccessLayer.Data
{
    public class ChatContext : DbContext
    {
        public DbSet<Conversation>?  Conversations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://chatapi.documents.azure.com:443/",
                "jGUO5JZK9M6hET3WXQ7FiWj9wVHQUMbnssb13QAaHOsDFzGsnsUeVUWQWu9x43HaQdMbYf6GdMk5CmzjSMmauw==",
                "chatapi");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>().ToContainer("Conversations").HasPartitionKey(c => c.Id);

            modelBuilder.Entity<Conversation>().OwnsMany(p => p.Messages);
            modelBuilder.Entity<Conversation>().OwnsMany(p => p.Participants);
        }
    }
}
