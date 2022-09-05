

namespace FlatRockTechnology.OnlineMarket.Models.Orders
{
    public class OrderProductModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public long Quantity { get; set; }
        public long PriceOfSingleProduct { get; set; }
    }
}