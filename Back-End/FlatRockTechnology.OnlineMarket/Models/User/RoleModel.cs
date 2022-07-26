
namespace FlatRockTechnology.OnlineMarket.Models.Users
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string NormalizedName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}