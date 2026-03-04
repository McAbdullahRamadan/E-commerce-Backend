using Domain.Entities.Product;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.System
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; }
        public string OTP { get; set; }
        public DateTime OTPExpirationDate { get; set; }
        public DateTime? LastOtpSent { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; } = new List<ApplicationUserClaim>();
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; } = new List<ApplicationUserLogin>();
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; } = new List<ApplicationUserToken>();
        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<WishlistItem> WishlistItems { get; set; } = new HashSet<WishlistItem>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<ApplicationUserPasswordHistory> PasswordHistories { get; set; } = new List<ApplicationUserPasswordHistory>();
    }
}