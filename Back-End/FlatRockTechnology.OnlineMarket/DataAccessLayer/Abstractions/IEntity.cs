using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Abstractions
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        DateTime? CreatedAt { get; set; }
        Guid? CreatedBy { get; set; }
        DateTime? ModifiedAt { get; set; }
        Guid? ModifiedBy { get; set; }
    }
}
