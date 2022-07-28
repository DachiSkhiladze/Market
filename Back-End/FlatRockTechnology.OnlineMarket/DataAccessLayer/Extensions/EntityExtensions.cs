using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureEntityForAdding(this IEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;
        }
    }
}
