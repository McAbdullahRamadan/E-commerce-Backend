using Domain.Common;
using Domain.Entities.System;

namespace Domain.Entities.Product
{
    public class Review : BaseAuditableEntity<Guid>
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Rating { get; set; } // 1-5

        public string Comment { get; set; }
    }
}

