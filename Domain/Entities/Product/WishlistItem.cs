using Domain.Entities.System;

namespace Domain.Entities.Product
{
    public class WishlistItem : BaseEntity<Guid>
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
