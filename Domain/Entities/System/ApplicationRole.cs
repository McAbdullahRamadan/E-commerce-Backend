using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.System
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName) : base(roleName)
        {
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; } = new List<ApplicationRoleClaim>();
        public virtual ICollection<ApplicationRoleTranslation> Translations { get; set; } = new List<ApplicationRoleTranslation>();
    }
}
