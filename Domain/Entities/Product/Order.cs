using Domain.Common;
using Domain.Entities.Product.Enums;
using Domain.Entities.System;

namespace Domain.Entities.Product
{
    public class Order : BaseAuditableEntity<Guid>
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        public string ShippingAddress { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}
