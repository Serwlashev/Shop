using Domain.Entity;

namespace Domain.Repository
{
    public interface IUnitOfWork
    {
        IRepository<long, Product> ProductRepository { get; }
        void SaveChangesAsync();
    }
}
