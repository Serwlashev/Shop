using Core.Domain.Entity;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IRepository<long, Product> ProductsRepository { get; }
        IRepository<long, Category> CategoriesRepository { get; }
        IRepository<long, User> AccountsRepository { get; }
        Task SaveChangesAsync();
    }
}
