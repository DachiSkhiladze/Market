namespace FlatRockTechnology.OnlineMarket.Models.Users
{
    public class UserRoleModel
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}