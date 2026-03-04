using Domain.Entities.Product;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repository;

namespace Infrastructure.RepositoryData
{
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
