namespace Domain.Entities.Product
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
