using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Individual.Abstractions;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Individual.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MarketContext context) : base(context)
        {

        }
    }
}
