

namespace FlatRockTechnology.OnlineMarket.Models.Categories
{
    public class ProductCategoryModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}