

namespace FlatRockTechnology.OnlineMarket.Models.Addresses
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}