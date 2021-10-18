using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using Infrastructure.Persistence.Implementation.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationContext;
        private ICategoriesRepository<long, Category> _categoriesRepository;
        private IProductsRepository<long, Product> _productsRepository;
        private IAccountsRepository<long, User> _accountsRepository;
        private ICartRepository<long, CartItem> _cartRepository;

        public IProductsRepository<long, Product> ProductsRepository
            => _productsRepository ??= new ProductsRepository(_applicationContext);
        public ICategoriesRepository<long, Category> CategoriesRepository
            => _categoriesRepository ??= new CategoriesRepository(_applicationContext);
        public IAccountsRepository<long, User> AccountsRepository
            => _accountsRepository ??= new AccountsRepository(_applicationContext);

        public ICartRepository<long, CartItem> CartRepository
            => _cartRepository ??= new CartRepository(_applicationContext);

        public UnitOfWork(ApplicationDbContext context)
        {
            _applicationContext = context;
        }

        public async Task SaveChangesAsync(CancellationToken token = default)
            => await _applicationContext.SaveChangesAsync(token).ConfigureAwait(false);
    }
}
