using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IRepository<long, Product> ProductsRepository { get; }
        IRepository<long, Category> CategoriesRepository { get; }
        Task SaveChangesAsync();
    }
}
