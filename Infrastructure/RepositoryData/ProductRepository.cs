using Domain.Entities.Product;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repository;

namespace Infrastructure.RepositoryData
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
