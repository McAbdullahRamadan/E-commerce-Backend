using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.System
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
