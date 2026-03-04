using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.System
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
