using Database.Implementation.Repositories;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Infrastructure.Database;
using System.Threading.Tasks;

namespace Database.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationContext;
        private IRepository<long, Category> _categoriesRepository;
        private IRepository<long, Product> _productsRepository;

        public IRepository<long, Product> ProductsRepository
            => _productsRepository ??= new ProductsRepository(_applicationContext);
        public IRepository<long, Category> CategoriesRepository
            => _categoriesRepository ??= new CategoriesRepository(_applicationContext);

        public UnitOfWork(ApplicationDbContext context)
        {
            _applicationContext = context;
        }

        public async Task SaveChangesAsync()
            => await _applicationContext.SaveChangesAsync();
    }
}
