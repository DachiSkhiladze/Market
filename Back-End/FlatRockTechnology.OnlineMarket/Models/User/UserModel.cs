

namespace FlatRockTechnology.OnlineMarket.Models.Users
{
    public class UserModel : UserLoginModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public bool? IsDisabled { get; set; }
        public ICollection<string>? Roles { get; set; }
    }
}