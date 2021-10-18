using Core.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IProductsRepository<long, Product> ProductsRepository { get; }
        ICategoriesRepository<long, Category> CategoriesRepository { get; }
        IAccountsRepository<long, User> AccountsRepository { get; }
        ICartRepository<long, CartItem> CartRepository { get; }
        Task SaveChangesAsync(CancellationToken token = default);
    }
}
