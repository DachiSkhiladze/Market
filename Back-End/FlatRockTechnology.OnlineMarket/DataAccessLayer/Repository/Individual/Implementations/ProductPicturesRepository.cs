using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Individual.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Individual.Implementations
{
    public class ProductPicturesRepository : Repository<ProductPictures>, IProductPicturesRepository
    {
        public ProductPicturesRepository(MarketContext context) : base(context)
        {

        }
    }
}
