

namespace FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.Category
{
    public class ProductCategoryModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid SubCategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}