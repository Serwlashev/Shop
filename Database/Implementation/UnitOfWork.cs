using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using Infrastructure.Persistence.Implementation.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationContext;
        private IRepository<long, Category> _categoriesRepository;
        private IRepository<long, Product> _productsRepository;
        private IRepository<long, User> _accountsRepository;

        public IRepository<long, Product> ProductsRepository
            => _productsRepository ??= new ProductsRepository(_applicationContext);
        public IRepository<long, Category> CategoriesRepository
            => _categoriesRepository ??= new CategoriesRepository(_applicationContext);
        public IRepository<long, User> AccountsRepository
            => _accountsRepository ??= new AccountsRepository(_applicationContext);

        public UnitOfWork(ApplicationDbContext context)
        {
            _applicationContext = context;
        }

        public async Task SaveChangesAsync()
            => await _applicationContext.SaveChangesAsync();
    }
}
