using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.RepositoryData
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly AppDbContext _dbContext;
        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IPhotoRepository PhotoRepository { get; }
        public UnitOfwork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            ProductRepository = new ProductRepository(_dbContext);
            CategoryRepository = new CategoryRepository(_dbContext);
            PhotoRepository = new PhotoRepository(_dbContext);
        }
    }
}
