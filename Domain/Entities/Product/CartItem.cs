namespace Domain.Entities.Product
{
    public class CartItem : BaseEntity<Guid>
    {
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
