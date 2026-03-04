using Domain.Common;

namespace Domain.Entities.System
{
    public class ApplicationUserPasswordHistory : BaseAuditableEntity<Guid>
    {
        public string UserId { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
