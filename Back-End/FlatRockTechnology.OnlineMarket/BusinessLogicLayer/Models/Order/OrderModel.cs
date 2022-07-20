

namespace FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.Order
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public Guid AddressId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}