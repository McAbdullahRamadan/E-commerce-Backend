using Domain.Entities.Product;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repository;

namespace Infrastructure.RepositoryData
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
