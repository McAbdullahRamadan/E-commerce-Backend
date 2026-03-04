using Domain.Entities.System;

namespace Domain.Entities.Product
{
    public class Cart : BaseEntity<Guid>
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CartItem> Items { get; set; } = new HashSet<CartItem>();
    }
}
