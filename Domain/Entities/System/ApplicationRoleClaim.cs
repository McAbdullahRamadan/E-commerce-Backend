using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.System
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; } = null!;

    }
}