namespace Domain.Entities.Product
{
    public class Photo : BaseEntity<Guid>
    {
        public string ImageName { get; set; }
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
