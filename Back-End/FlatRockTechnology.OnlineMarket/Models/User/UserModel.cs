

namespace FlatRockTechnology.OnlineMarket.Models.Users
{
    public class UserModel : UserRegisterModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NormalizedEmail { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string City { get; set; }
        public string Role { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string EmailVerificationCode { get; set; }
        public string PasswordRecoveryCode { get; set; }
    }
}