

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.Address
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}