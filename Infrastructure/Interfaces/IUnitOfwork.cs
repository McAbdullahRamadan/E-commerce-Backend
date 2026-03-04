namespace Infrastructure.Interfaces
{
    public interface IUnitOfwork
    {
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IPhotoRepository PhotoRepository { get; }
    }
}
