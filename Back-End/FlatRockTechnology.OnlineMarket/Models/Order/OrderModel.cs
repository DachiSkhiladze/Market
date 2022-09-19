

namespace FlatRockTechnology.OnlineMarket.Models.Orders
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public Guid AddressId { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderProductModel> orders { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}