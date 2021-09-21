using Core.Domain.Entity;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IProductsRepository<long, Product> ProductsRepository { get; }
        ICategoriesRepository<long, Category> CategoriesRepository { get; }
        IAccountsRepository<long, User> AccountsRepository { get; }
        Task SaveChangesAsync();
    }
}
