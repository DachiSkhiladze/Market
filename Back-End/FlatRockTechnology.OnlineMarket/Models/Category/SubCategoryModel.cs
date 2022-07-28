

namespace FlatRockTechnology.OnlineMarket.Models.Categories
{
    public class SubCategoryModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}