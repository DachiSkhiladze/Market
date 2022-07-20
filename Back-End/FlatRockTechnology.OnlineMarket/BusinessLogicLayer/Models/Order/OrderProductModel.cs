

namespace FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.Order
{
    public class OrderProductModel
    {
        public Guid Id { get; set; }
        public long ProductId { get; set; }
        public Guid OrderId { get; set; }
        public long Quantity { get; set; }
        public long PriceOfSingleProduct { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}