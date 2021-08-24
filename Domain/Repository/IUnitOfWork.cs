using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUnitOfWork
    {
        IRepository<long, Product> ProductsRepository { get; }
        IRepository<long, Category> CategoriesRepository { get; }
        Task SaveChangesAsync();
    }
}
