using TaskAuthenticationAuthorization.Models.Enums;

namespace TaskAuthenticationAuthorization.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Buyer;
        public BuyerType Type { get; set; } = BuyerType.Regular;
        public Discount Discount { get; set; } = Discount.O;
    }
}
