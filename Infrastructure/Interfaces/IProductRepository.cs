using Domain.Entities.Product;
using Infrastructure.Repository;

namespace Infrastructure.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
