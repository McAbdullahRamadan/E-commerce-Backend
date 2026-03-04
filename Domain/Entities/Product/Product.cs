using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Product
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
