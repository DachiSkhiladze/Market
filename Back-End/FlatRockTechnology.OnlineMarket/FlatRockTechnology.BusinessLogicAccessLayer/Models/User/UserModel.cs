

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.User
{
    public class UserModel : UserLoginModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public bool? IsDisabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public ICollection<string>? Roles { get; set; }
    }
}